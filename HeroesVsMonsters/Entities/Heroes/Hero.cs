using HeroesVsMonsters.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters.Entities.Heroes
{
    public class Hero : Entity
    {
        public override void Attack(Entity t)
        {
            int damage = Dice.Throws(DiceType.D4, 2,1);
            switch (true) 
            {
                case true when StatEntity[StatType.Str] < 5 :
                    {
                        damage -= 1;
                        break;
                    }
                case true when StatEntity[StatType.Str] < 15:
                    {
                        damage += 1;
                        break;
                    }
                default:
                    {
                        damage += 2;
                        break;
                    }
            }
            t.TakeDamage(damage);
        }
        protected override void GenerateStats()
        {
            StatEntity[StatType.Str] = Dice.Throws(DiceType.D10, 5, 3);
            StatEntity[StatType.Stamina] = Dice.Throws(DiceType.D10, 5, 3);
        }
    }
}
