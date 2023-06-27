using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters
{
    public class Hud
    {


        public static void ShowHud()
        {
            int desiredWidth = 180; // Largeur souhaitée de la console
            int desiredHeight = 50; // Hauteur souhaitée de la console

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
            int longueur1 = 150;
            int largeur1 = 3;

            int longueur2 = 30;
            int largeur2 = 38;

            int longueur3 = 150;
            int largeur3 = 35;

            int longueur4 = 150;
            int largeur4 = 12;

            int longueur5 = 30;
            int largeur5 = 12;

            // Dessiner le premier rectangle
            string premiereLigne1 = new string('-', longueur1);
            sb.AppendLine(premiereLigne1);

            for (int i = 0; i < largeur1 - 2; i++)
            {
                string ligneVerticale1 = "|" + new string(' ', longueur1 - 2) + "|";
                sb.AppendLine(ligneVerticale1);
            }

            string derniereLigne1 = new string('-', longueur1);
            sb.AppendLine(derniereLigne1);

            // Dessiner le rectangle supplémentaire en dessous du premier rectangle
            string espace3 = new string(' ', longueur1 - 2);

            for (int i = 0; i < largeur3; i++)
            {
                sb.AppendLine("|" + espace3 + "|");
            }

            // Dessiner la première ligne du rectangle supplémentaire
            sb.AppendLine(new string('-', longueur1));

            // Dessiner le rectangle supplémentaire à droite du premier rectangle
            for (int i = 0; i < largeur2; i++)
            {
                sb.AppendLine("|" + espace3 + "|" + new string(' ', longueur2) + "|");
            }

            // Dessiner la dernière ligne du rectangle supplémentaire
                sb.AppendLine(new string('-', longueur1) + new string('-', longueur2));

            // Dessiner le rectangle supplémentaire en dessous du troisième rectangle
            string espace4 = new string(' ', longueur1 - 2);

            for (int i = 0; i < largeur4; i++)
            {
                sb.AppendLine("|" + espace4 + "|");
            }

            // Dessiner la première ligne du rectangle supplémentaire
            sb.AppendLine(new string('-', longueur1));

            // Dessiner le rectangle supplémentaire à droite du quatrième rectangle
            string espace5 = new string(' ', longueur4);

            for (int i = 0; i < largeur5; i++)
            {
                sb.AppendLine("|" + espace4 + "|" + espace5 + "|");
            }

            // Dessiner la dernière ligne du rectangle supplémentaire
            sb.AppendLine(new string('-', longueur1) + new string('-', longueur5));
            Console.WriteLine(sb);
        }
    }
}
