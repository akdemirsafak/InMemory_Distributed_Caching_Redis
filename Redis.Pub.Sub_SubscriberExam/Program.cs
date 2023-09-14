// See https://aka.ms/new-console-template for more information
using StackExchange.Redis;

Console.WriteLine("Hello, World!");

ConnectionMultiplexer connectionMultiplexer= await ConnectionMultiplexer.ConnectAsync("localhost:1234");
ISubscriber subscriber= connectionMultiplexer.GetSubscriber();


string message=Console.ReadLine();
await subscriber.SubscribeAsync("channelName", (channel, message) =>
{
    Console.WriteLine(message);
});
Console.Read();
