using HeroesVsMonsters.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters.Menus
{
    public enum GameButton
    {
        NewGame,
        Quitter
    }
    public static class GameMenu
    {
        public static void Show(int cursorPosi, (int, int) posInitiale)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(posInitiale.Item1, posInitiale.Item2);
            Logo.ShowLogoTitle();
            int i = 1;
            foreach (GameButton gb in Enum.GetValues(typeof(GameButton)))
            {
                Console.SetCursorPosition(posInitiale.Item1 + 25, posInitiale.Item2 +6+ i);
                if (cursorPosi == i)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write((cursorPosi == i ? "=>" : "") + $" {gb}");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("           ");
                i++;
            }

        }
        public static int GetSizeMenu()
        {
            return Enum.GetValues(typeof(GameButton)).Length;
        }
    }
}
