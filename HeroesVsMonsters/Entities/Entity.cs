using HeroesVsMonsters.Entities.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            StatEntity[StatType.Hp] = StatEntity[StatType.Strength] + (StatEntity[StatType.Stamina] < 25 ? -2 : +3);
            CurrentHp = StatEntity[StatType.Hp];
            Name = name;
        }

        protected Entity()
        {
            StatEntity = new Stats();
            GenerateStats();
            StatEntity[StatType.Hp] = StatEntity[StatType.Strength] + (StatEntity[StatType.Stamina] < 25 ? -2 : +3);
            CurrentHp = StatEntity[StatType.Hp];
        }

        public string Name { get; set; }
        public int CurrentHp { get; protected set; }

        public Stats StatEntity { get; set; }
        public bool IsDefented { get; protected set; }

        public  bool IsAlive()
        {
            return CurrentHp > 0;
        }
        public virtual void TakeDamage(int amount)
        {
            
            string message = $"{Name} subit {amount} de dégats";
            Hud.ShowInDialogBox(message, message.Length);
            Console.ReadKey();
            Hud.ShowInDialogBox(" ", 1);
            CurrentHp -= amount;
            if (!IsAlive())
            {
                CurrentHp = 0;
                RaiseDieEvent();
            }
        }
        public abstract void Attack(Entity target);

        protected abstract void GenerateStats();

        public virtual void ShowStats()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"------------------------------\n" +
                          $"{CurrentHp}/{StatEntity[StatType.Hp]}\n" +
                          $"Force:{StatEntity[StatType.Strength]}\n" +
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
