using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redis.OM.Modeling;

namespace ProjectsSharedClasses.MadMagic.Characters
{
    [Document(StorageType = StorageType.Json, Prefixes = new[] { "CharacterInfo" })]
    public class CharacterInfo
    {
        [RedisIdField][Indexed] public string? Id { get; set; }
        [Indexed] public int MaxHitPoints { get; set; }
        [Indexed] public string Name { get; set; } = "";
        [Indexed] public string? Description { get; set; }
    }
}
