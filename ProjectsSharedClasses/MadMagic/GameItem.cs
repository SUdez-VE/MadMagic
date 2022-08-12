using Redis.OM.Modeling;
using Newtonsoft.Json;

namespace ProjectsSharedClasses.MadMagic
{
    [Document(StorageType = StorageType.Json, Prefixes = new[] { "GameItem" })]
    public class GameItem
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static T? FromJson<T>(string jsonGameItem) where T : GameItem
        {
            return JsonConvert.DeserializeObject<T>(jsonGameItem);
        }

        [RedisIdField][Indexed] public string? Id { get; set; }
        [Indexed] public virtual bool IsBlock { get; set; } = false;
        [Indexed] public string? PathToImage { get; set; }
        [Indexed] public System.Drawing.Point Position { get; set; } = new System.Drawing.Point(0, 0);
    }
}