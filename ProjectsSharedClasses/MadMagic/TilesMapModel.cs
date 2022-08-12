using Redis.OM.Modeling;
using System.Drawing;

namespace ProjectsSharedClasses.MadMagic
{
    [Document(StorageType = StorageType.Json, Prefixes = new[] { "TilesMap" })]
    public class TilesMapModel : GameItem
    {
        [Indexed] public string[] TilesRows { get; set; } = Array.Empty<string>();
        [Indexed] public string? Name { get; set; }
        [Indexed] public string PathToBackImage { get; set; } = "/img/maps/default.png";
        [Indexed(CascadeDepth = 1)] public Size Size { get; set; }
    }
}


