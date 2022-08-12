using Redis.OM.Modeling;

namespace ProjectsSharedClasses.MadMagic.Spell
{
    [Document(StorageType = StorageType.Json, Prefixes = new[] { "SpellDeck" })]
    public class SpellDeck
    {
        [Indexed] public string? Name { get; set; }
        [Indexed] public List<SpellCard> Cards { get; set; } = new List<SpellCard>();
    }
}
