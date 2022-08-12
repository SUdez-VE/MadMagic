using Redis.OM.Modeling;
using ProjectsSharedClasses.MadMagic.Spell;
using System.Drawing;

namespace ProjectsSharedClasses.MadMagic
{
    [Document(StorageType = StorageType.Json, Prefixes = new[] { "GameModel" })]
    public class GameModel
    {
        [RedisIdField][Indexed] public string? Id { get; set; }
        [Indexed] public string? GameName { get; set; }
        [Indexed] public string? Password { get; set; }
        [Indexed(CascadeDepth = 1)] public TilesMapModel? Map { get; set; }

        [Indexed(CascadeDepth = 3)] public Dictionary<PlayerModel, Characters.CharacterGameItem> PlayerCharacterDict { get; set; } = new Dictionary<PlayerModel, Characters.CharacterGameItem>();
        [Indexed(CascadeDepth = 1)] public SpellObject[] Spells { get; set; } = Array.Empty<SpellObject>();
        public GameItem[] AllItems => Spells.Select(s => (GameItem)s).Concat(PlayerCharacterDict.Values.Select(ch => (GameItem)ch)).ToArray();
        
        public void AddSpell(SpellObject spellObject)
        {
            var newPos = spellObject.Position;
            if (newPos.Y < 0 || newPos.Y > Map?.TilesRows.Length - 1 || newPos.Y < 0 || newPos.X > Map?.TilesRows[newPos.Y].Length || Map?.TilesRows[newPos.Y][newPos.X] == '1' || AllItems.Any(item => item.Position == newPos && item.IsBlock))
            {

            }
        }
        private bool TryMoveTo(GameItem item, int x, int y)
        {
            Point newPos = item.Position;
            newPos += new Size(x, y);
            if (newPos.Y < 0 || newPos.Y > Map?.TilesRows.Length - 1 || newPos.Y < 0 || newPos.X > Map?.TilesRows[newPos.Y].Length || Map?.TilesRows[newPos.Y][newPos.X] == '1' || AllItems.Any(item => item.Position == newPos && item.IsBlock))
                return false;
            else
            {
                item.Position = newPos;
                return true;
            }
        }
        public void UpdateGame(Dictionary<PlayerModel, Tuple<CharacterActions, Directions?>> playerIdActionsDict)
        {
            if (playerIdActionsDict.Any(pair => !PlayerCharacterDict.Any(p => p.Key.Id == pair.Key.Id)))
                throw new ArgumentOutOfRangeException("Один из игроков не присутствует в данной игре");
            else
            {
                foreach(var pair in playerIdActionsDict)
                {
                    switch(pair.Value.Item1)
                    {
                        case CharacterActions.MoveRight:
                            TryMoveTo(PlayerCharacterDict.Single(p => pair.Key.Id == p.Key.Id).Value, 1, 0);
                            break;
                        case CharacterActions.MoveUp:
                            TryMoveTo(PlayerCharacterDict.Single(p => pair.Key.Id == p.Key.Id).Value, 0, -1);
                            break;
                        case CharacterActions.MoveLeft:
                            TryMoveTo(PlayerCharacterDict.Single(p => pair.Key.Id == p.Key.Id).Value, -1, 0);
                            break;
                        case CharacterActions.MoveDown:
                            TryMoveTo(PlayerCharacterDict.Single(p => pair.Key.Id == p.Key.Id).Value, 1, 0);
                            break;
                        case CharacterActions.Concentrate: PlayerCharacterDict.Single(p => p.Key.Id == pair.Key.Id).Value.GainMana(); break;
                        case CharacterActions.Cast1: PlayerCharacterDict.Single(p => p.Key.Id == pair.Key.Id).Value.CastSpell(0, pair.Value.Item2); break;
                        case CharacterActions.Cast2: PlayerCharacterDict.Single(p => p.Key.Id == pair.Key.Id).Value.CastSpell(1, pair.Value.Item2); break;
                        case CharacterActions.Cast3: PlayerCharacterDict.Single(p => p.Key.Id == pair.Key.Id).Value.CastSpell(2, pair.Value.Item2); break;
                        default: break;
                    }
                }
            }
        }

    }
    public enum CharacterActions
    {
        MoveRight,
        MoveLeft,
        MoveUp,
        MoveDown,
        Cast1,
        Cast2,
        Cast3,
        Concentrate
    }
    public enum Directions
    {

        Top = 0,
        TopRight = 1,
        Right = 2,
        BottomRight = 3,
        Bottom = 4,
        BottomLeft = 5,
        Left = 6,
        TopLeft = 7
    }
}

