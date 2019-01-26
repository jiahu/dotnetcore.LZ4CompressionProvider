# dotnetcore.LZ4CompressionProvider
Custom lz4 Compressed Web API Response. Accept-Encoding: lz4

Here is the request/response logs via [Insomnia](https://insomnia.rest/)
  
  
  > GET /api/values HTTP/1.1  
  > Host: localhost:12358  
  > User-Agent: insomnia/6.3.2   
  > Accept-Encoding: lz4  
  > Accept: */*  
  < HTTP/1.1 200 OK  
  < Date: Fri, 25 Jan 2019 11:50:33 GMT  
  < Content-Type: application/json; charset=utf-8  
  < Server: Kestrel  
  < Transfer-Encoding: chunked  
  < Content-Encoding: lz4  
  < Vary: Accept-Encoding  
  < Author: Ben  
    Received 9 B chunk  
    Received 8 B chunk  
    Received 72 B chunk  
    Received 5 B chunk  
    Connection #5 to host localhost left intact  
