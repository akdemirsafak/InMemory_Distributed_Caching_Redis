using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Distributed.Caching.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistributedCacheController : ControllerBase
    {
        private readonly IDistributedCache _distributedCache;
        public DistributedCacheController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        [HttpPost]
        public async Task<IActionResult> Set(string name, string surname)
        {
            await _distributedCache.SetStringAsync("name", name, options: new()
            {
                AbsoluteExpiration = DateTime.UtcNow.AddSeconds(30), //5 saniyenin sürekli yenilendiğini varsayarsak 30 saniyeyi geçtiği an veriler silinir.
                SlidingExpiration = TimeSpan.FromSeconds(5)
            });
            await _distributedCache.SetAsync("surname", Encoding.UTF8.GetBytes(surname),
             options: new()
             {
                 AbsoluteExpiration = DateTime.UtcNow.AddSeconds(30),
                 SlidingExpiration = TimeSpan.FromSeconds(5) //5 saniye işlem yapılmadığı takdirde cache bellekten silinecek
             });
            //Set Byte formatta tutar.
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var name = await _distributedCache.GetStringAsync("name");
            var surnameBinary = await _distributedCache.GetAsync("surname");
            var surname = Encoding.UTF8.GetString(surnameBinary!); //Eğer süre 5 saniyeyi geçtikten sonra get isteğinde bulunursak yani ; cache bellekte byte olarak tutulan bir bilgiyi çağırırsak ve üzerinde işlem yapmak istersek burada hata fırlatacaktır.

            return Ok(
                new
                {
                    name,
                    surname
                }
            );
        }
    }
}