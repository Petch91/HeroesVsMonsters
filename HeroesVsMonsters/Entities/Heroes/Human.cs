using HeroesVsMonsters.Entities.Monsters;
using HeroesVsMonsters.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters.Entities.Heroes
{
    public class Human : Hero
    {
        public Human(string name) : base(name)
        {
            SpecialSkill = "Boule de feu";
            X = 7;
            Y = 8;
        }

        public override string SpecialSkill { get; }

        public override void Attack(Entity t)
        {
            Console.WriteLine("Coup d'épée dans ta gueule");
            base.Attack(t); 
        }
        protected override void GenerateStats()
        {
            base.GenerateStats();
            StatEntity[StatType.Str] += 1;
            StatEntity[StatType.Stamina] += 1;
        }

        public override void UseSkill(Entity e)
        {
            Console.WriteLine("Boule de feu dans ta gueule");
            e.TakeDamage(Dice.Throws(DiceType.D6, 2, 2));
        }
    }
}
