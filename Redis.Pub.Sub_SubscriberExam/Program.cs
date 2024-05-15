// See https://aka.ms/new-console-template for more information
using StackExchange.Redis;

Console.WriteLine("Hello, Im Subscriber");

ConnectionMultiplexer connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync("localhost:1234");
ISubscriber subscriber = connectionMultiplexer.GetSubscriber();

await subscriber.SubscribeAsync(new RedisChannel("channelName", RedisChannel.PatternMode.Auto), (channel, message) =>
{
    Console.WriteLine(message);
});
Console.Read();
