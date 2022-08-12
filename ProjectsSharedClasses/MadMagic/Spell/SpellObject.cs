using Redis.OM.Modeling;
using ProjectsSharedClasses.MadMagic;
using System.Drawing;

namespace ProjectsSharedClasses.MadMagic.Spell
{
    [Document(StorageType = StorageType.Json, Prefixes = new[] { "SpellObject" })]
    public class SpellObject : GameItem
    {
        public SpellObject(SpellLogic spellLogic)
        {
            SpellLogic = spellLogic;
        }
        [Indexed] public int Counter { get; set; }
        [Indexed(CascadeDepth = 1)] public SpellLogic SpellLogic { get; set; }
        [Indexed] public int Speed { get; set; }
        [Indexed] public int Bounces { get; set; }
        [Indexed] public int Size { get; set; }
        [Indexed] public int Charges { get; set; }
        [Indexed] Directions CurrentDirection { get; set; } = Directions.Top;
        public void MoveByOne(Directions dir)
        {
            switch(dir)
            {
                case Directions.TopRight:
                    Position += new Size(+1, -1);
                    break;
                case Directions.Right: Position += new Size(+1, 0); break;
                case Directions.BottomRight: Position += new Size(+1, +1); break;
                case Directions.Bottom: Position += new Size(0, +1); break;
                case Directions.BottomLeft: Position += new Size(-1, +1); break;
                case Directions.Left: Position += new Size(-1, 0); break;
                case Directions.TopLeft: Position += new Size(-1, -1); break;
                default:
                case Directions.Top: Position += new Size(0, -1); break;
            }
        }
        public void MoveBySpeed()
        {
            for(int i = 0; i < Speed; i++)
            {
                var moveArray = SpellLogic.MoveLogic?.Split("/");
                if (moveArray != null || moveArray.Length > 0)
                {
                    int newDirInd = (int)CurrentDirection + Convert.ToInt32(moveArray[Counter % moveArray.Length]);
                    while (newDirInd < 0)
                    {
                        newDirInd += 8;
                    }
                    while (newDirInd > 7)
                    {
                        newDirInd -= 8;
                    }
                    CurrentDirection = (Directions)newDirInd;
                    MoveByOne(CurrentDirection);
                }
            }
            
        }
    }
}


