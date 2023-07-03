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
            Sprite = "🧍🏻‍";
            SpecialSkill = "Boule de feu";
            X = 7;
            Y = 8;
        }

        public override void Attack(Entity t)
        {
            Hud.ShowInDialogBox("Coup d'épée dans ta gueule");
            base.Attack(t); 
        }
        protected override void GenerateStats()
        {
            base.GenerateStats();
            StatEntity[StatType.Strength] += 1;
            StatEntity[StatType.Stamina] += 1;
        }

        public override void UseSkill(Entity e)
        {
            Hud.ShowInDialogBox("Boule de feu dans ta gueule");
            e.TakeDamage(Dice.Throws(DiceType.D6, 2, 2));
        }
    }
}
