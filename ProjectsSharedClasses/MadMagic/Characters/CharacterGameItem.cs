using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsSharedClasses.MadMagic.Spell;
using Redis.OM.Modeling;

namespace ProjectsSharedClasses.MadMagic.Characters
{
    [Document(StorageType = StorageType.Json, Prefixes = new[] { "CharacterGameItem" })]
    public class CharacterGameItem : GameItem
    {
        [Indexed] public string OwnerId { get; set; }
        [Indexed(CascadeDepth = 1)] CharacterInfo CharacterInfo {get; set;}
        [Indexed] public override bool IsBlock { get; set; } = true;
        [Indexed(CascadeDepth = 2)] SpellDeck Deck { get; set; }
        [Indexed] public int CurrentHitPoints { get; set; }
        [Indexed] public short CurrentMana { get; set; } = 2;
        public void GainMana()
        {
            CurrentMana++;
            if (CurrentMana > 2)
                CurrentMana = 2;
        }
        public SpellObject CastSpell(int index, Directions? direction)
        {
            if (direction == null)
                direction = Directions.Top;
            SpellLogic logic = Deck.Cards[index].SpellLogic;
            SpellObject obj = new SpellObject(logic)
            {
                Bounces = logic.Bounce,
                PathToImage = logic.PathToImage,
                Charges = logic.Charges,
                Counter = 0,
                Size = logic.Size,
                Speed = logic.Speed,
                IsBlock = false
            };
            obj.Position = Position + direction switch
            {
                Directions.Top => new Size(0, -1),
                Directions.TopRight => new Size(1, -1),
                Directions.Right => new Size(1, 0),
                Directions.BottomRight => new Size(1, 1),
                Directions.Bottom => new Size(0, 1),
                Directions.BottomLeft => new Size(-1, 1),
                Directions.Left => new Size(-1, 0),
                Directions.TopLeft => new Size(-1, -1),
                _ => new Size(0, -1)
            };
            return obj;

            
        }
    }
}
