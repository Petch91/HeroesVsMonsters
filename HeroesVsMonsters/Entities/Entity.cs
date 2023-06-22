using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            GenerateStats();
            StatEntity[StatType.Hp] = StatEntity[StatType.Str] + StatEntity[StatType.Stamina] < 15 ? -2 : +3;
            StatEntity[StatType.CurrentHp] = StatEntity[StatType.Hp];
        }

        public Stats StatEntity { get; set; }

        public  bool IsAlive()
        {
            return StatEntity[StatType.CurrentHp] > 0;
        }
        public void TakeDamage(int amount)
        {
            StatEntity[StatType.CurrentHp] -= amount;
            if(!IsAlive() ) StatEntity[StatType.CurrentHp] = 0;
        }
        public abstract void Attack(Entity target);

        protected abstract void GenerateStats();
    }
}
