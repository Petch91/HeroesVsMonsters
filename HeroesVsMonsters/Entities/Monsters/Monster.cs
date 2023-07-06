using HeroesVsMonsters.Entities.Heroes;
using HeroesVsMonsters.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters.Entities.Monsters
{
   public abstract class Monster : Entity
   {

      public abstract Inventory Loot { get; }
      public override void Attack(Entity t)
      {
         int damage = Dice.Throws(DiceType.D4);
         switch (true)
         {
            case true when StatEntity[StatType.Strength] < 5:
               {
                  damage -= 1;
                  break;
               }
            case true when StatEntity[StatType.Strength] < 15:
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
         damage = t.IsDefented ? damage / 2 : damage;
         t.TakeDamage(damage);
         if (t is Hero h) Hud.ShowInHeroFightBox(h);

      }
      public void Kill()
      { 
         CurrentHp =0;
      }
      protected override void GenerateStats()
      {
         StatEntity[StatType.Strength] = Dice.Throws(DiceType.D6, 5, 3);
         StatEntity[StatType.Stamina] = Dice.Throws(DiceType.D6, 5, 3);
         StatEntity[StatType.Speed] = Dice.Throws(DiceType.D10, 5, 2);
      }

   }
}
