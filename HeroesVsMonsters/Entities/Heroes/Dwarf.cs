using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters.Entities.Heroes.Heroes
{
    public class Dwarf : Hero
    {
        public Dwarf(string name) : base(name)
        {
            SpecialSkill = "Défense";
        }

        public override string SpecialSkill { get; }
        

        public override void Attack(Entity t)
        {
            Console.WriteLine("Coup de hache dans ta gueule");
            base.Attack(t);
        }
        protected override void GenerateStats()
        {
            base.GenerateStats();
            StatEntity[StatType.Stamina] += 2;
        }

        public override void UseSkill(Entity e)
        {
            IsDefented = true;
        }
    }
}
