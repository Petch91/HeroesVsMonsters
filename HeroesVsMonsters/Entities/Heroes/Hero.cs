using HeroesVsMonsters.Entities.Monsters;
using HeroesVsMonsters.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters.Entities.Heroes
{
    public  class Hero : Entity
    {
        public Hero(string name) : base(name)
        {
            Sac[ItemType.Or] = 50;
            Sac[ItemType.Cuir] = 0;

        }
        
    public string Sprite { get; protected set; }
    public  string SpecialSkill { get; protected set; }

        public int X { get; protected set; }
        public int Y { get; protected set; }


        public Inventory Sac = new Inventory();
        public (int, int) MoveHero(Map m)
        {
            ConsoleKeyInfo cki;
            (int, int) previousPos = (X, Y);
            do
            {
                cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (m.MoveAccepted((X, Y - 1)))
                            {
                                Y--;
                                if (Y < 0) Y = 0;
                            }
                            return previousPos;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (m.MoveAccepted((X, Y + 1)))
                            {
                                Y++;
                                if (Y > m.yMax - 1) Y = m.yMax - 1;
                            }
                            return previousPos;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (m.MoveAccepted((X - 1, Y)))
                            {
                                X--;
                                if (X < 0) X = 0;
                            }
                            return previousPos;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (m.MoveAccepted((X + 1, Y)))
                            {
                                X++;
                                if (X > m.xMax - 1) X = m.xMax - 1;
                            }
                            return previousPos;
                        }
                }
            } while (true);
        }
        public override void Attack(Entity t)
        {
            int damage = Dice.Throws(DiceType.D4, 2, 1);
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
            t.TakeDamage(damage);
            Hud.ShowInEnemyFightBox(t);
        }
        public void Heal()
        {
            int amount = Dice.Throws(DiceType.D4, 2, 2);
            CurrentHp += amount;
            Hud.ShowInDialogBox($"{Name} se soigne de {amount} HP");
        }

        protected void Rest()
        {
            CurrentHp = StatEntity[StatType.Hp];
        }
        protected void Loot(Monster m)
        {
            Inventory temp = new Inventory();
            foreach (ItemType item in Sac.Items.Keys)
            {
                temp[item] = Sac.Items[item];
            }
            Sac += m.Loot;
            foreach (ItemType item in Sac.Items.Keys)
            {
                if (temp[item] != Sac.Items[item])
                {
                    Hud.ShowInDialogBox($"Vous avez recuperé sur {m.Name}, {Sac.Items[item] - temp[item]} {item}");
                }
            }
            Hud.ShowInDialogBox("");
        }
        public void DieAction(Entity e)
        {
            Rest();
            Hud.ShowInEnemyFightBox(e);
            if (e is Monster m)
            {
                Hud.ShowInDialogBox($"{m.Name} est mort");
                Loot(m);
            }

        }
        public virtual void UseSkill(Entity e) { }
        protected override void GenerateStats()
        {
            StatEntity[StatType.Strength] = Dice.Throws(DiceType.D10, 5, 3);
            StatEntity[StatType.Stamina] = Dice.Throws(DiceType.D10, 5, 2);
            StatEntity[StatType.Speed] = Dice.Throws(DiceType.D10, 5, 4);
        }

        public override void ShowStats()
        {
            Console.WriteLine(Name);
            base.ShowStats();
        }
    }
}
