using HeroesVsMonsters.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters.Entities.Monsters
{
    public class Dragon : Monster
    {
        public Dragon()
        {
            Name = "Le dragon";
            Loot = new Inventory();
            Loot[ItemType.Or] = Dice.Throws(DiceType.D6);
            Loot[ItemType.Cuir] = Dice.Throws(DiceType.D4);
        }

        public override Inventory Loot { get; }

        public override void Attack(Entity t)
        {
            Console.WriteLine("Dracofeu attaque Lance-Flammes");
            base.Attack(t);
        }

        protected override void GenerateStats()
        {
            base.GenerateStats();
            StatEntity[StatType.Stamina] += 1;
        }
    }
}
