var http = require("http");

var server = http.createServer(function(req, res){
    console.log(req.url);
    res.end("<html><head></head><body><h1>" + req.url + "</h1></body></html>");
});

// Another way of creating HTTP server and listening to 'request' event
// var server = http.createServer();
// server.on('request', function(req, res){
// 	console.log(req.url);
//     res.end("<html><head></head><body><h1>" + req.url + "</h1></body></html>");
// })

server.listen(3000);