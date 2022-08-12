using Microsoft.AspNetCore.Mvc;
using Redis.OM.Searching;
using Redis.OM;
using ProjectsSharedClasses.MadMagic;

namespace RedisApi.Controllers;


[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly RedisCollection<PlayerModel> _players;
    private readonly RedisConnectionProvider _provider;
    public PlayerController(RedisConnectionProvider provider)
    {
        _provider = provider;
        _players = (RedisCollection<PlayerModel>)provider.RedisCollection<PlayerModel>();
    }

    [HttpPost]
    public async Task<PlayerModel> AddPlayer([FromBody] PlayerModel player)
    {
        await _players.InsertAsync(player);
        return player;
    }


}