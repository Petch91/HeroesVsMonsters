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
        public Hero(string name) : base(name)
        {
            Sac[ItemType.Or] = 50;
            Sac[ItemType.Cuir] = 0;

        }
        public abstract string SpecialSkill { get; }

        public int X { get; protected set; }
        public int Y { get; protected set; }


        public Inventory Sac = new Inventory();
        public (int,int) MoveHero(int xMax,int yMax)
        {
            ConsoleKeyInfo cki;
            (int, int) previousPos = (X,Y);
            cki = Console.ReadKey();
            switch (cki.Key)
            {
                case ConsoleKey.LeftArrow:
                    {
                        Y--;
                        if (Y < 0) Y = 0;
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        Y++;
                        if (Y > yMax-1) Y = yMax - 1;
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        X--;
                        if (X < 0) X = 0;
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        X++;
                        if (X > yMax - 1) X = yMax - 1;
                        break;
                    }
            }
            return previousPos;
        }
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
        public void Heal()
        {
            int amount = Dice.Throws(DiceType.D4, 2, 2);
            StatEntity[StatType.CurrentHp] += amount;
            Console.WriteLine($"{Name} se soigne de {amount} HP");
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
            {
                Console.WriteLine($"{m.Name} est mort");
                Loot(m);
            }

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
