using System;
using System.Threading.Tasks;
using Grpc.Core;
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

            var replies = client.SayHello(new HelloRequest { Name = "Laurent" });

            await foreach (var reply in replies.ResponseStream.ReadAllAsync())
            {
                Console.WriteLine(reply.Message);
            }
        }
    }
}
