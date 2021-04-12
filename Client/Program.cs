using System;
using System.Threading.Tasks;
using Grpc.Core;
using Interface;
using MagicOnion.Client;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            //var channel = GrpcChannel.ForAddress("https://localhost:12345");
            var channel = new Channel("localhost", 12345, ChannelCredentials.Insecure);
            var client = StreamingHubClient.Connect<ISampleHub, ISampleReceiver>(channel, new SampleReceiver());

            Console.WriteLine("JoinAsync()");
            await client.JoinAsync("thisclient");

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("SendMessageAsync()");
                await client.SendMessageAsync("クライアントからの送信:" + i);
                await Task.Delay(1000);
            }

            Console.WriteLine("LeaveAsync()");
            await client.LeaveAsync();
            await Task.Delay(100);

            //Console.WriteLine("WaitForDisconnect()");
            //client.WaitForDisconnect();
            Console.WriteLine("DisposeAsync()");
            await client.DisposeAsync();
            Console.WriteLine("ShutdownAsync()");
            await channel.ShutdownAsync();
            Console.WriteLine("プログラム終了！");
        }
    }
}
