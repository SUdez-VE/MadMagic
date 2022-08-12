using ProjectsSharedClasses.MadMagic.Spell;
using System.Text.Json;

namespace MadMagicRazor.Services
{
    public class SpellsService
    {
        public IWebHostEnvironment Env { get; }
        private string apiUrl = "http://redisapi:80/Spell/";
        private HttpClient _client;
        public SpellsService(IWebHostEnvironment env)
        {
            Env = env;
            _client = new HttpClient();
        }
        public async Task<List<SpellLogic>> GetSpellsAsync()
        {
            return JsonSerializer.Deserialize<List<SpellLogic>>(await (await _client.GetAsync(apiUrl + "logic/all")).Content.ReadAsStringAsync());
        }
    }
}
