using HeroesVsMonsters.Entities;
using HeroesVsMonsters.Entities.Heroes;
using HeroesVsMonsters.Entities.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters.Utils
{
    public class Map
    {
        public Map(Hero h)
        {
            xMax = 35;
            yMax = 148;
            ShowedMap = new string[xMax, yMax];
            GenerateMap(h);
        }

        public int xMax { get; }
        public int yMax { get; }
        public string[,] ShowedMap { get; }
        private void GenerateMap(Hero h)
        {
            for (int i = 0; i < ShowedMap.GetLength(0); i++)
            {
                for (int j = 0; j < ShowedMap.GetLength(1); j++)
                {
                    ShowedMap[i, j] = " ";
                    ShowedMap[i, j] = " ";
                }
            }
            ShowedMap[h.X, h.Y] = "☻";
            ShowedMap[h.X, h.Y] = "☻";
            int countMonsters = 0;
            for (int i = 0; i < ShowedMap.GetLength(0) && countMonsters <= 15; i++)
            {
                for (int j = 0; j < ShowedMap.GetLength(1) && countMonsters <= 15; j++)
                {
                    Random r = new Random();
                    switch (r.Next(500))
                    {
                        case 25:
                            ShowedMap[i,j] = "⌂";
                            break;
                        case 50:
                            ShowedMap[i, j] = "♣";
                            break;
                        case 75:
                            ShowedMap[i, j] = "█";
                            break;
                        default:
                            ShowedMap[i, j] = " ";
                            break;
                    }
                }
            }
            ShowedMap[h.X, h.Y] = "☻";
        }
        public void ShowMap()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            for (int i = 0; i < ShowedMap.GetLength(0); i++)
            {
                Console.SetCursorPosition(1, 5+i);
                for (int j = 0; j < ShowedMap.GetLength(1); j++)
                {
                    if (ShowedMap[i, j] == "☻")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(ShowedMap[i, j], ConsoleColor.White);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }

                    else Console.Write(ShowedMap[i, j]);
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }


        public void ModifyMaps(string modif, (int, int) newPosition)
        {
            ShowedMap[newPosition.Item1, newPosition.Item2] = modif;
            ShowedMap[newPosition.Item1, newPosition.Item2] = modif;
        }
        public void ModifyMaps(string modif, (int, int) newPosition, (int, int) oldPosition)
        {
            ShowedMap[oldPosition.Item1, oldPosition.Item2] = " ";
            ShowedMap[newPosition.Item1, newPosition.Item2] = modif;
        }

        public bool MoveAccepted((int, int) newPosition) 
        {
            return ShowedMap[newPosition.Item1, newPosition.Item2] == " "; 
        }

    }
}
