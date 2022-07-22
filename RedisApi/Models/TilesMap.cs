using Redis.OM.Modeling;

namespace Redis.OM.Skeleton.Model;

[Document(StorageType = StorageType.Json, Prefixes = new[] { "TilesMap" })]
public class TilesMap
{
        [Indexed] public string[] TilesRows {get; set;} = Array.Empty<string>();
        //[RedisIdField] [Indexed] public string? Id {get; set;}
        [Indexed] public string? Name {get; set;}
        [Indexed] public string? PathToBackImage {get; set;}
}
