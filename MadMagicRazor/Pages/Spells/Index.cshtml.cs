using MadMagicRazor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectsSharedClasses.MadMagic.Spell;

namespace MadMagicRazor.Pages.Spells
{
    public class IndexModel : PageModel
    {
        private SpellsService SpellsService { get; set; }
        public List<SpellLogic> Spells { get; private set; }
        public IndexModel(SpellsService spellsService)
        {
            SpellsService = spellsService;
        }

        public async Task OnGetAsync()
        {
            Spells = await SpellsService.GetSpellsAsync();
        }

    }
}
