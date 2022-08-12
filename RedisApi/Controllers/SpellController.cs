using Microsoft.AspNetCore.Mvc;
using Redis.OM.Searching;
using Redis.OM;
using ProjectsSharedClasses.MadMagic.Spell;

namespace RedisApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SpellController : ControllerBase
{
    private readonly RedisCollection<SpellLogic> _logics;
    private readonly RedisCollection<SpellCard> _cards;
    private readonly RedisConnectionProvider _provider;
    public SpellController(RedisConnectionProvider provider)
    {
        _provider = provider;
        _logics = (RedisCollection<SpellLogic>)provider.RedisCollection<SpellLogic>();
        _cards = (RedisCollection<SpellCard>)provider.RedisCollection<SpellCard>();
    }

    [HttpPost("logic")]
    public async Task<SpellLogic> AddLogic([FromBody] SpellLogic logic)
    {
        await _logics.InsertAsync(logic);
        return logic;
    }

    [HttpPost("card")]
    public async Task<SpellCard> AddCard([FromBody] SpellCard card)
    {
        await _cards.InsertAsync(card);
        return card;
    }

    [HttpGet("filterType")]
    public IList<SpellLogic> FilterLogicByType([FromQuery] string typePart)
    {
        return _logics.Where(x => x.Type!.ToLower().Contains(typePart.ToLower())).ToList();
    }

    [HttpGet("logic/all")]
    public IList<SpellLogic> GetAllLogics()
    {
        return _logics.ToList();
    }

    [HttpGet("logic/{id}")]
    public SpellLogic? GetLogicById([FromRoute]string id)
    {
        return _logics.FirstOrDefault(x => x.Id == id);
    }
    [HttpPut("logic")]
    public async Task<SpellLogic> UpdateLogic([FromBody] SpellLogic logic)
    {
        await _logics.UpdateAsync(logic);
        return logic;
    }

    [HttpPut("card")]
    public async Task<SpellCard> UpdateCard([FromBody] SpellCard card)
    {
        await _cards.UpdateAsync(card);
        return card;
    }
    [HttpGet("card/{id}")]
    public SpellCard? GetCardById([FromRoute]string id)
    {
        return _cards.FirstOrDefault(x => x.Id == id);
    }

    [HttpGet("cards/all")]
    public IList<SpellCard> GetAllCards()
    {
        return _cards.ToList();
    }
    [HttpDelete("logic/{id}")]
    public async Task<IActionResult> DeleteLogic([FromRoute]string id)
    {
        await _provider.Connection.UnlinkAsync($"SpellLogic:{id}");
        return NoContent();
    }

    [HttpDelete("card/{id}")]
    public async Task<IActionResult> DeleteCard([FromRoute] string id)
    {
        await _provider.Connection.UnlinkAsync ($"SpellCard :{id}");
        return NoContent();
    }
}