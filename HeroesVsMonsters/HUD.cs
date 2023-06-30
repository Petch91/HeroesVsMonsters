using HeroesVsMonsters.Entities;
using HeroesVsMonsters.Entities.Heroes;
using HeroesVsMonsters.Entities.Monsters;
using HeroesVsMonsters.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters
{
    public class Hud
    {
        public static void ShowInDialogBox(string message,int messageSize)
        {
            Console.SetCursorPosition(20,2);
            Console.WriteLine(new string(' ',100));
            Console.SetCursorPosition(80 - messageSize, 2);
            Console.WriteLine(message + new string(' ', 30));

        }
        public static void ShowInStatBox(Hero h)
        {
            Console.SetCursorPosition(155, 2);
            Console.WriteLine($"|{h.Name}|");
            int i =0;
            foreach(StatType stat in h.StatEntity.StatsD.Keys) 
            {
                Console.SetCursorPosition(155, 3+i);
                Console.WriteLine($"{stat} : {h.StatEntity.StatsD[stat]}");
                i++;
            }
        }

        public static void ShowInHeroFightBox(Hero h) 
        {
            Console.SetCursorPosition(77, 42);
            Console.WriteLine($"{h.Name} : {h.CurrentHp}/{h.StatEntity.StatsD[StatType.Hp]}     ");
        }
        public static void ClearHeroFightBox()
        {
            Console.SetCursorPosition(77, 42);
            Console.WriteLine($"                     ");
        }
        public static void ShowInEnemyFightBox(Entity e)
        {
            Console.SetCursorPosition(3, 42);
            Console.WriteLine($"{e.Name} : {e.CurrentHp}/{e.StatEntity.StatsD[StatType.Hp]}     ");
        }
        public static void ClearEnemyFightBox()
        {
            Console.SetCursorPosition(3, 42);
            Console.WriteLine($"                     ");
        }
        public static void ShowInInventoryBox(Hero h)
        {
            Console.SetCursorPosition(155, 35);
            Console.WriteLine($"|Inventaire|");
            int i = 0;
            foreach (ItemType item in h.Sac.Items.Keys)
            {
                Console.SetCursorPosition(155, 36 + i);
                Console.WriteLine(h.Sac.Items[item] > 0 ? $"{item} : {h.Sac.Items[item]}":"");
                i++;
            }
        }
        public static void ClearMap(Map m) 
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            for (int i = 0; i < m.xMax; i++)
            {
                Console.SetCursorPosition(1, 5 + i);
                for (int j = 0; j < m.yMax; j++)
                {
                    Console.SetCursorPosition(1+j, 5 + i);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }
        public static void ShowHud()
        {
            int desiredWidth = 180; // Largeur souhaitée de la console
            int desiredHeight = 60; // Hauteur souhaitée de la console

            if (desiredWidth <= Console.LargestWindowWidth && desiredHeight <= Console.LargestWindowHeight)
            {
                Console.WindowWidth = desiredWidth;
                Console.WindowHeight = desiredHeight;
            }
            else
            {
                Console.WriteLine("Les dimensions souhaitées de la console sont trop grandes pour être ajustées.");
            }
            StringBuilder sb = new StringBuilder();
            int longueur1 = 180;
            int largeur1 = 3;

            int longueur2 = 30;

            int longueur3 = 150;
            int largeur3 = 35;

            int largeur4 = 12;

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            sb.AppendLine(new string('_', longueur1));

            for (int i = 0; i < largeur1; i++)
            {
                string ligneVerticale1 = "|" + new string(' ', longueur3 - 2) + "|" + new string(' ', longueur2 - 1) + "|";
                sb.AppendLine(ligneVerticale1);
            }

            string derniereLigne1 = "|" +new string('-', longueur3-2) +"|"+ new string(' ', longueur2-1) + "|";
            sb.AppendLine(derniereLigne1);

            for (int i = 0; i < largeur3; i++)
            {
                sb.AppendLine("|" + new string(' ', longueur3 - 2) + "|" + new string(' ', longueur2-1) + "|");
            }
            sb.AppendLine(new string("|" + new string('-', longueur3 - 2) + "|" + new string('-', longueur2 - 1) + "|"));
            for (int i = 0; i < largeur4; i++)
            {
                sb.AppendLine("|" + new string(' ', longueur3/2-2) + "|" + new string(' ', longueur3 / 2 - 1) + "|" + new string(' ', longueur2 - 1) + "|");
            }
            sb.AppendLine(new string('-', longueur1));
            Console.WriteLine(sb);
        }
    }
}
