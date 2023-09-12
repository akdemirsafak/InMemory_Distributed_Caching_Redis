using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemory.Caching.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class InMemoryController : ControllerBase
{
    private readonly IMemoryCache _memoryCache;

    public InMemoryController(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }
    [HttpGet]
    public IActionResult GetName()
    {

        //var cacheValue=_memoryCache.Get("name");
        //var cacheValue=_memoryCache.Get<string>("name");

        //Get methodunda değer gelmeme veya bir işlem sırasında Runtime hata alabilme durumunu ortadan kaldırmak için daha garanti bir yöntem olan TryGet kullanacağız.
        
        //Try ile : Değer gelmemesi durumunda substring methodu çalışamayacağı için hata üretecektir.
        //var cache_Value= _memoryCache.Get("name");
        //return Ok(cache_Value.ToString().Substring(3));

        if (_memoryCache.TryGetValue<string>("name",out string cacheValue))
        {
            return Ok(cacheValue.Substring(3));
        }
        return BadRequest();

    }
    [HttpGet("{name}")]
    public void SetName(string name)
    {
        _memoryCache.Set("name", name);
    }
    [HttpGet]
    public void SetDate()
    {
        //absolutetime sliding time ayarlarını yapalım : 
        _memoryCache.Set<DateTime>("date", DateTime.Now, options: new() 
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(30), //Bu verinin mutlak ömrü 30 saniye olacak.Cache'de 30 saniye tutulacak.
            SlidingExpiration=TimeSpan.FromSeconds(5), //Verinin ömrü  bu ömür bittikçe yeni veriler gelir. Bu verileri 5 saniye içerisinde kullanmazsak silinir.
        });
    }
    [HttpGet]
    public DateTime GetDate()
    {
        return _memoryCache.Get<DateTime>("date");
    }
}