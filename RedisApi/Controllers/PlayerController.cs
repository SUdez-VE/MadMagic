using Microsoft.AspNetCore.Mvc;
using Redis.OM.Searching;
using Redis.OM.Skeleton.Model;

namespace Redis.OM.Skeleton.Controllers;


[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly RedisCollection<Player> _players;
    private readonly RedisConnectionProvider _provider;
    public PlayerController(RedisConnectionProvider provider)
    {
        _provider = provider;
        _players = (RedisCollection<Player>)provider.RedisCollection<Player>();
    }

    [HttpPost]
    public async Task<Player> AddPlayer([FromBody] Player player)
    {
        await _players.InsertAsync(player);
        return player;
    }


}