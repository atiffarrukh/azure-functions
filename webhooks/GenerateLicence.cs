using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace webhooks
{
    public static class GenerateLicence
    {
        [FunctionName("GenerateLicence")]
        public static void Run([QueueTrigger("orders")]Order order,
        [Blob("licenses/{rand-guid}.lic")] TextWriter outputBlob,
         ILogger log)
        {
            outputBlob.WriteLine($"OrderId:{order.OrderId}");
            outputBlob.WriteLine($"Email:{order.Email}");
            outputBlob.WriteLine($"Price:{order.Price}");
            outputBlob.WriteLine($"ProductId:{order.ProductId}");
            outputBlob.WriteLine($"PurchaseDate:{DateTime.UtcNow}");
            var md5 = System.Security.Cryptography.MD5.Create();
            var hash = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(order.Email + "secret"));
            outputBlob.WriteLine($"SecretCode: {BitConverter.ToString(hash).Replace("-","")}", "");
        }
    }
}
