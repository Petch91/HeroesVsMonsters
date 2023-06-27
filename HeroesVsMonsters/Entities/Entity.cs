using HeroesVsMonsters.Entities.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HeroesVsMonsters.Entities
{
    
    public abstract class Entity
    {
        public event Action<Entity> DieEvent;
        protected Entity(string name)
        {
            StatEntity = new Stats();
            GenerateStats();
            StatEntity[StatType.Hp] = StatEntity[StatType.Str] + (StatEntity[StatType.Stamina] < 25 ? -2 : +3);
            StatEntity[StatType.CurrentHp] = StatEntity[StatType.Hp];
            Name = name;
        }

        protected Entity()
        {
            StatEntity = new Stats();
            GenerateStats();
            StatEntity[StatType.Hp] = StatEntity[StatType.Str] + (StatEntity[StatType.Stamina] < 25 ? -2 : +3);
            StatEntity[StatType.CurrentHp] = StatEntity[StatType.Hp];
        }

        public string Name { get; set; }

        public Stats StatEntity { get; set; }
        public bool IsDefented { get; protected set; }

        public  bool IsAlive()
        {
            return StatEntity[StatType.CurrentHp] > 0;
        }
        public virtual void TakeDamage(int amount)
        {
            Console.WriteLine($"{Name} subit {amount} de dégats");
            StatEntity[StatType.CurrentHp] -= amount;
            if (!IsAlive())
            {
                StatEntity[StatType.CurrentHp] = 0;
                RaiseDieEvent();
            }
        }
        public abstract void Attack(Entity target);

        protected abstract void GenerateStats();

        public virtual void ShowStats()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"------------------------------\n" +
                          $"{StatEntity[StatType.CurrentHp]}/{StatEntity[StatType.Hp]}\n" +
                          $"Force:{StatEntity[StatType.Str]}\n" +
                          $"Stamina: {StatEntity[StatType.Stamina]}\n"+
                          $"------------------------------"
                         );
            Console.WriteLine(sb);
        }

        protected void RaiseDieEvent()
        {
            DieEvent?.Invoke(this);
        }

    }
}
