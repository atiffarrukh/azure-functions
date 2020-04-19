module.exports = async function (context, order) {
    var message = {
        "personalizations": [ { "to": [ { "email": order.EmailId } ] } ],
       from: { email: "sender@contoso.com" },
       subject: "Order received. Order Number " + order.OrderId,
       content: [{
           type: 'text/plain',
           value: order
       }]
   };

   context.done(null, message);
};