using Redis.OM.Modeling;

namespace Redis.OM.Skeleton.Model;

[Document(StorageType = StorageType.Json, Prefixes = new[] { "Player" })]
public class Player{
    [RedisIdField] [Indexed] public string? Id {get; set;}
    [Indexed] public int HitPoints {get; set;}
    [Indexed] public string? NickName {get; set;}
    [Indexed(CascadeDepth = 1)] public SpellDeck[] Decks {get; set;} = Array.Empty<SpellDeck>();
    [Indexed(CascadeDepth = 1)] public SpellDeck? CurrentDeck {get; set;}
    [Indexed] public string? PathToImage {get; set;}
}