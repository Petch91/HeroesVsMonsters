using HeroesVsMonsters.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters.Entities.Monsters
{
    public class Wolf : Monster
    {
        public Wolf()
        {
            Name = "Le loup";
            Loot = new Inventory();
            Loot[ItemType.Cuir] = Dice.Throws(DiceType.D4);
        }

        public override Inventory Loot { get; }

        public override void Attack(Entity t)
        {
            
            string message = "AAAAHOOOOUUUUU";
            Hud.ShowInDialogBox(message, message.Length);
            Console.ReadKey();
            base.Attack(t);
        }
    }
}
