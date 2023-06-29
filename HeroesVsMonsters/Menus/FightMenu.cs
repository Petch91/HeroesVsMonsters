using HeroesVsMonsters.Entities.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters.Menus
{
    internal enum FightButton
    {
        Attaque,
        Spéciale,
        Soin,
        Fuir
    }
    public class FightMenu
    {
        public static void Show(Hero fighter1, int cursorPosi,(int,int) posInitiale)
        {

            Console.SetCursorPosition(posInitiale.Item1,posInitiale.Item2);
            Console.WriteLine($"------|{fighter1.Name}|------");
            int i = 1;
            foreach(FightButton fb in Enum.GetValues(typeof(FightButton)))
            {
                Console.SetCursorPosition(posInitiale.Item1 , posInitiale.Item2+i);
                Console.WriteLine((cursorPosi == i ? "=>" : "") + $" {fb}     ");
                i++;

            }

        }

        public static int GetSizeMenu()
        {
            return Enum.GetValues(typeof(FightButton)).Length;
        }
    }
}
