using HeroesVsMonsters.Entities;
using HeroesVsMonsters.Entities.Heroes;
using HeroesVsMonsters.Entities.Heroes.Heroes;
using HeroesVsMonsters.Entities.Monsters;
using HeroesVsMonsters.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters.Utils
{
    public static class Game
    {

        public static void Navigation(Hero h, Map m)
        {
            m.ShowMap();
            Hud.ShowInInventoryBox(h);
            (int, int) previousPos = h.MoveHero(m);
            m.ModifyMaps("☻", (h.X, h.Y), previousPos);
            if (IsFight())
            {
                Hud.ClearMap(m);

                Fight(h, ChooseMonster(h));
            }
            //Console.Clear();
        }
        private static Monster ChooseMonster(Hero h)
        {
            Random r = new Random();
            int rng = r.Next(4);

            switch (rng)
            {


                case 2:
                    Orc orc = new Orc();
                    Logo.ShowOrcLogo();
                    orc.DieEvent += h.DieAction;
                    return orc;
                case 3:
                    Dragon dragon = new Dragon();
                    Logo.ShowDragonLogo();
                    dragon.DieEvent += h.DieAction;
                    return dragon;
                default:
                    Wolf wolf = new Wolf();
                    Logo.ShowWolfLogo();
                    wolf.DieEvent += h.DieAction;
                    return wolf;
            }
        }
        public static bool IsFight()
        {

            Random random = new Random();
            if (random.Next(26) == 25)
            {
                return true;
            }
            return false;
        }
        public static void Fight(Hero fighter1, Entity fighter2)
        {
            Hud.ShowInDialogBox($"{fighter2.Name} vous attaque, soyez prêt!");
            Hud.ShowInHeroFightBox(fighter1);
            Hud.ShowInEnemyFightBox(fighter2);
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
                FightMenu.ClearMenu((152, 42));
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
                //Console.ReadKey();
                if (fighter2.IsAlive())
                {
                    fighter2.Attack(fighter1);
                }
                //Console.ReadKey();
            }
            Hud.ClearHeroFightBox();
            Hud.ClearEnemyFightBox();
        }

        public static bool NewGame(out CharacterButton cb)
        {
            int index = 1;
            int choix = 1;
            ConsoleKeyInfo cki;
            do
            {
                GameMenu.Show(index, (0, 5));
                cki = Console.ReadKey();
                Menu.Browse(cki, GameMenu.GetSizeMenu(), ref index);
            } while (cki.Key != ConsoleKey.Enter);
            choix = Menu.SelectAction(index);
            if (choix == 1)
            {
                Console.Clear();
                do
                {
                    SelectCharMenu.Show(index, (0, 5));
                    cki = Console.ReadKey();
                    Menu.Browse(cki, SelectCharMenu.GetSizeMenu(), ref index);
                } while (cki.Key != ConsoleKey.Enter);
                choix = Menu.SelectAction(index);
                switch (choix)
                {
                    case 1: cb = CharacterButton.Humain; return true;
                    case 2: cb = CharacterButton.Nain; return true;
                }
            }
            cb = CharacterButton.Nain;
            return false;
        }
    }
}


