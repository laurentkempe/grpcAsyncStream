using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using grpcAsyncStreamServer;

namespace grpcAsyncStreamClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var reply = await client.SayHelloAsync(new HelloRequest { Name = "Laurent" });
            
            Console.WriteLine(reply.Message);
        }
    }
}
