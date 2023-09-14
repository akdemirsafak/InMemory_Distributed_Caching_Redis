// See https://aka.ms/new-console-template for more information
using StackExchange.Redis;

Console.WriteLine("Hello, World!");

ConnectionMultiplexer connectionMultiplexer= await ConnectionMultiplexer.ConnectAsync("localhost:1234");
ISubscriber subscriber= connectionMultiplexer.GetSubscriber();


while (true)
{
    Console.Write("Message : ");
    string message=Console.ReadLine();
    await subscriber.PublishAsync("channelName", message);
}
