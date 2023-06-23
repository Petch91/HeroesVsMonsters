using HeroesVsMonsters.Entities.Monsters;
using HeroesVsMonsters.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters.Entities.Heroes
{
    public abstract class Hero : Entity
    {
        public Hero(string name)
        {
            Sac[ItemType.Or] = 50;
            Sac[ItemType.Cuir] = 0;
            Name = name;
        }

        public string Name { get; set; }

        public abstract string SpecialSkill { get; }


        public Inventory Sac = new Inventory();
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
            Console.WriteLine($"Attaque de {damage}");
            t.TakeDamage(damage);
        }
        public void Heal()
        {
            StatEntity[StatType.CurrentHp] += Dice.Throws(DiceType.D4, 2, 2);
        }

        protected void Rest()
        {
            StatEntity[StatType.CurrentHp] = StatEntity[StatType.Hp];
        }
        protected void Loot(Monster m)
        {
            Sac += m.Loot;
        }
        public void DieAction(Entity e)
        {
            Rest();
            if(e is Monster m)
            Loot(m);
        }
        public abstract void UseSkill(Entity e);
        protected override void GenerateStats()
        {
            StatEntity[StatType.Str] = Dice.Throws(DiceType.D10, 5, 3);
            StatEntity[StatType.Stamina] = Dice.Throws(DiceType.D10, 5, 3);
        }

        public override void ShowStats()
        {
            Console.WriteLine(Name);
            base.ShowStats();
        }
    }
}
