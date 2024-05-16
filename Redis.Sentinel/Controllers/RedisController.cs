using Microsoft.AspNetCore.Mvc;
using Redis.Sentinel.Services;

namespace Redis.Sentinel.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class RedisController : ControllerBase
{


    [HttpPost("{key}/{value}")]
    public async Task<IActionResult> Set(string key,string value)
    {
        var redis =await RedisService.RedisMasterDatabase();
        await redis.StringSetAsync(key,value);
        return Ok();
    }

    [HttpGet("{key}")]
    public async Task<IActionResult> Get(string key)
    {
        var redis =await RedisService.RedisMasterDatabase();
        var data = await redis.StringGetAsync(key);
        return Ok(data.ToString());
    }
}
