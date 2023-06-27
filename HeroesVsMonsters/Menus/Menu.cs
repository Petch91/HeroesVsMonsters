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
        private static void ShowMenuFight(Hero fighter1, int cursorPosi)
        {
            //(int, int) cursorPosi = (0, 0);
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"------|{fighter1.Name}|------");
            sb.AppendLine((cursorPosi == 1 ? "=>" : "") + $"- Attaque ");
            sb.AppendLine((cursorPosi == 2 ? "=>" : "") + $"- {fighter1.SpecialSkill} ");
            sb.AppendLine((cursorPosi == 3 ? "=>" : "") + $"- Soin ");
            sb.AppendLine((cursorPosi == 4 ? "=>" : "") + $"- Fuir ");
            sb.AppendLine("------------------------------");
            Console.WriteLine(sb);
        }

        public static int SelectAction(Hero fighter)
        {
            ConsoleKeyInfo cki;
            Console.SetCursorPosition(0, 1);
            int cursorPosi = 1;
            do
            {
                ShowMenuFight(fighter, cursorPosi);
                cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            cursorPosi--;
                            if (cursorPosi <= 0) cursorPosi = 4;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            cursorPosi++;
                            if (cursorPosi > 4) cursorPosi = 1;
                            break;
                        }
                }
            } while (cki.Key != ConsoleKey.Enter);
            Console.Clear();
            return cursorPosi;
        }

    }
}
