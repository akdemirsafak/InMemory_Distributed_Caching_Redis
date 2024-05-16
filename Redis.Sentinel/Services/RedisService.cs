using StackExchange.Redis;

namespace Redis.Sentinel.Services;

public class RedisService
{
    static ConfigurationOptions sentinelOptions => new()
    {
        EndPoints =
        {
            { "localhost", 6383 },
            { "localhost", 6384 },
            { "localhost", 6385 }
        },
        CommandMap=CommandMap.Sentinel,
        AbortOnConnectFail=false //Default true'dur. Sentinel'a bağlanamazsa hata fırlatır.False yaptığımız için exception fırlatmaz.
    };

    static ConfigurationOptions masterOptions => new()
    {
        AbortOnConnectFail = false
    };

    public static async Task<IDatabase> RedisMasterDatabase()
    {
        using var sentinelConnection =await ConnectionMultiplexer.ConnectAsync(sentinelOptions);
        System.Net.EndPoint masterEndpoint = null;
        foreach (System.Net.EndPoint endpoint in sentinelConnection.GetEndPoints()) //Bağlantı sağladığımız herhangi bir sentinel server'dan master'ın adresini alıyoruz.
        {
            IServer server = sentinelConnection.GetServer(endpoint);
            if (!server.IsConnected) //Sentinel Server'lardan birisinde hata varsa ve ona bağlanmak istiyorsak bir sonrakine geçiyoruz.
                continue;
            masterEndpoint=await server.SentinelGetMasterAddressByNameAsync("mymaster"); //Master'ın adresini alıyoruz. sentinel configurasyonunda belirlediğimiz mymaster ismi ile.
            //Burada gelecek olan masterEndpoint ip'si internal ip'dir. Bu yüzden dışarıdan erişim sağlamak için bir proxy kullanabiliriz.
            break; //Master'ın adresini aldıktan sonra döngüden çıkıyoruz.
        }
        var localMasterIP= masterEndpoint.ToString() switch
        {
            "172.21.0.2:6379" => "localhost:6379", //master ve slave'leri belirlerken kullandığımız ip'ler.Bunu docker'da çalıştığımız için kullandık.                                         
            "172.21.0.3:6379" => "localhost:6380",//Arkaplanda bu çalışmaları gerçekleştiren kütüphaneler vardır.
            "172.21.0.4:6379" => "localhost:6381",//3 tane slave'imiz var 3 ünün de ip'sini belirttik.
            "172.21.0.5:6379" => "localhost:6382",
            _ => throw new Exception("Master IP not found")
        };
        ConnectionMultiplexer masterConnection = ConnectionMultiplexer.Connect(localMasterIP); //Master'a bağlanıyoruz.
        IDatabase database = masterConnection.GetDatabase();
        return database;
    }
}
