using HeroesVsMonsters.Entities.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters.Menus
{
    public static class Menu
    {
        public static int SelectAction(int cursorPos )
        {
            return cursorPos;
        }

        public static void Browse(ConsoleKeyInfo cki, int size, ref int cursorPosi)
        {

            switch (cki.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        cursorPosi--;
                        if (cursorPosi <= 0) cursorPosi = size;
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        cursorPosi++;
                        if (cursorPosi > size) cursorPosi = 1;
                        break;
                    }
            }
        }

    }
}
