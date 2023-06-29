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
            sb.AppendLine(new string('-', longueur1));

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
