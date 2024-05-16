using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Redis.SessionCache.Controllers;

[ApiController]
[Route("[controller]")]
public class RedisController : ControllerBase
{
    [HttpPost]
    public IActionResult SetSession()
    {
        HttpContext.Session.Set("name", Encoding.UTF8.GetBytes("Şafak AKDEMİR"));
        return Ok("Session set.");
    }
    [HttpGet]
    public IActionResult GetSession()
    {
        if (HttpContext.Session.TryGetValue("name", out byte[] value))
            Console.WriteLine(Encoding.UTF8.GetString(value));

        return Ok(Encoding.UTF8.GetString(value));
    }
}
