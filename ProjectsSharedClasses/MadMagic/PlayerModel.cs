using Redis.OM.Modeling;
using ProjectsSharedClasses.MadMagic.Spell;
using ProjectsSharedClasses.MadMagic.Characters;

namespace ProjectsSharedClasses.MadMagic
{
    [Document(StorageType = StorageType.Json, Prefixes = new[] { "PlayerModel" })]
    public class PlayerModel
    {
        [RedisIdField][Indexed] public string? Id { get; set; }        
        [Indexed] public string? NickName { get; set; }
        [Indexed(CascadeDepth = 2)] public Dictionary<CharacterInfo, SpellDeck[]>? Decks { get; set; }
    }
}

