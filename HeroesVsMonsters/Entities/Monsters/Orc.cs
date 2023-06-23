using HeroesVsMonsters.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters.Entities.Monsters
{
    public class Orc : Monster
    {
        public Orc()
        {
            Name = "L'orc";
            Loot = new Inventory();
            Loot[ItemType.Or] = Dice.Throws(DiceType.D6);
        }

        public override Inventory Loot { get; }

        public override void Attack(Entity t)
        {
            Console.WriteLine("Je vais te bouffer");
            base.Attack(t);
        }
        protected override void GenerateStats()
        {
            base.GenerateStats();
            StatEntity[StatType.Str] += 1;
        }
    }
}
