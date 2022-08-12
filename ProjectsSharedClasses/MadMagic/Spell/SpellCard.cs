using ProjectsSharedClasses.MadMagic.Characters;
using Redis.OM.Modeling;

namespace ProjectsSharedClasses.MadMagic.Spell
{
    [Document(StorageType = StorageType.Json, Prefixes = new[] { "SpellCard" })]
    public class SpellCard
    {
        public SpellCard(SpellLogic logic)
        {
            SpellLogic = logic;
        }
        [RedisIdField][Indexed] public string? Id { get; set; }
        [Indexed(CascadeDepth = 1)] public CharacterInfo Owner { get; set; }
        [Indexed] public string? Name { get; set; }
        [Indexed] public string? Text { get; set; }
        [Indexed] public string? FullImagePath { get; set; }
        [Indexed] public string? SmallImagePath { get; set; }
        [Indexed(CascadeDepth = 1)] public SpellLogic SpellLogic  { get; set; }
    }
}
