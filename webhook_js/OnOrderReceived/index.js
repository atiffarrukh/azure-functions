module.exports = async function (context, req, res) {
    context.log('JavaScript HTTP trigger function processed a request.');

    context.bindings.order = req.body;

    context.res = {
        body: {"success": true},
        contentType: 'application/json'
     };

    context.done();
};