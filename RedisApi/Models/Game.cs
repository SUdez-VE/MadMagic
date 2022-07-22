using Redis.OM.Modeling;

namespace Redis.OM.Skeleton.Model;

[Document(StorageType = StorageType.Json, Prefixes = new[] { "Game" })]
public class GameModel {
    [RedisIdField] [Indexed] public string? Id {get; set;}
    [Indexed] public string? GameName {get; set;}
    [Indexed(CascadeDepth = 1)] public TilesMap? Map {get; set;}
    [Indexed(CascadeDepth = 2)] public Player[] Players {get; set;} = Array.Empty<Player>();
    [Indexed(CascadeDepth = 1)] public SpellObject[] Spells {get; set;} = Array.Empty<SpellObject>();
}