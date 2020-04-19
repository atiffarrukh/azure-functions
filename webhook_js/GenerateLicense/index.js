const md5 = require("./md5")
module.exports = async function (context, order) {
    context.log('JavaScript queue trigger function processed work item', JSON.stringify(order));
    context.bindings.licensesBlob = {
        OrderId: order.OrderId,
        EmailId: order.EmailId,
        "PurchaseDate": new Date(),
        "SecretCode": (md5(order.OrderId + "secret"))
    }
    
    context.done();
};