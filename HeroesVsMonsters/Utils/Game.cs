using HeroesVsMonsters.Entities;
using HeroesVsMonsters.Entities.Heroes;
using HeroesVsMonsters.Entities.Monsters;
using HeroesVsMonsters.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters.Utils
{
    public static class Game
    {

        public static void Navigation(Hero h, Map m)
        {
            string monster = " ";
            (int, int) monsterPosi;
            m.ShowMap();
            (int, int) previousPos = h.MoveHero(m.xMax, m.yMax);
            m.ModifyMaps("H",(h.X,h.Y), previousPos );
            if (IsFight(h,m, out monster, out monsterPosi))
            {
                m.ModifyShowedMap(monster, monsterPosi);
                Fight(h,ChooseMonster(h, monster));
                if (h.IsAlive()) m.ModifyMaps(" ", monsterPosi);
            }
            Console.Clear();
        }
        private static Monster ChooseMonster(Hero h, string monster) 
        {
            switch (monster) 
            {
                case "L":
                    {
                        Wolf wolf = new Wolf();
                        wolf.DieEvent += h.DieAction;
                        return wolf;
                    }
                case "O":
                    {
                        Orc orc = new Orc();
                        orc.DieEvent += h.DieAction;
                        return orc;
                    }
                case "D":
                    {
                        Dragon dragon = new Dragon();
                        dragon.DieEvent += h.DieAction;
                        return dragon;
                    }
            }
            return new Wolf();
        }

        public static bool IsFight(Hero h,Map m, out string monster, out (int,int) monsterPos )
        {
            switch (true)
            {
                case true when m.HiddenMap[h.X + 1, h.Y] != " ":
                    {
                        monster = m.HiddenMap[h.X + 1, h.Y];
                        monsterPos = (h.X + 1, h.Y);
                        return m.HiddenMap[h.X + 1, h.Y] != " ";
                    }
                case true when m.HiddenMap[h.X - 1, h.Y] != " ":
                    {
                        monster = m.HiddenMap[h.X - 1, h.Y];
                        monsterPos = (h.X - 1, h.Y);
                        return m.HiddenMap[h.X - 1, h.Y] != " ";
                    }
                case true when m.HiddenMap[h.X, h.Y + 1] != " ":
                    {
                        monster = m.HiddenMap[h.X, h.Y + 1];
                        monsterPos = (h.X, h.Y + 1);
                        return m.HiddenMap[h.X, h.Y + 1] != " ";
                    }
                case true when m.HiddenMap[h.X, h.Y - 1] != " ":
                    {
                        monster = m.HiddenMap[h.X, h.Y - 1];
                        monsterPos = (h.X, h.Y - 1);
                        return m.HiddenMap[h.X, h.Y - 1] != " ";
                    }
            }
            monster = " ";
            monsterPos = (0, 0);
            return false;
        }
        public static void Fight(Hero fighter1, Entity fighter2)
        {
            Console.WriteLine($"{fighter2.Name} vous attaque, soyez prêt!");
            int choix = 1; 
            while (fighter1.IsAlive() && fighter2.IsAlive())
            {
                int index = 1;
                ConsoleKeyInfo cki;
                do
                {
                    FightMenu.Show(fighter1, index, (152, 42));
                    cki = Console.ReadKey();
                    Menu.Browse(cki, FightMenu.GetSizeMenu(), ref index);
                } while (cki.Key != ConsoleKey.Enter);
                
                choix = Menu.SelectAction(index);
                switch (choix)
                {
                    case 1:
                        fighter1.Attack(fighter2);
                        break;
                    case 2:
                        fighter1.UseSkill(fighter2);
                        break;
                    case 3:
                        fighter1.Heal();
                        break;
                    case 4: throw new NotImplementedException();
                }
                Console.ReadKey();
                if (fighter2.IsAlive())
                {
                    fighter2.Attack(fighter1);
                }
                Console.ReadKey();
            }
            if (!fighter2.IsAlive())
            {
                foreach (ItemType item in fighter1.Sac.Items.Keys)
                {
                    Console.WriteLine($"{item} : {fighter1.Sac[item]} ");
                }
            }
        }

    }
}
