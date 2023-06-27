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
            xMax = 15;
            yMax = 15;
            HiddenMap = new string[xMax, yMax];
            ShowedMap = new string[xMax, yMax];
            GenerateMap(h);
        }

        public int xMax { get; }
        public int yMax { get; }
        public string[,] HiddenMap { get; }
        public string[,] ShowedMap { get; }
        private void GenerateMap(Hero h)
        {
            for (int i = 0; i < HiddenMap.GetLength(0); i++)
            {
                for (int j = 0; j < HiddenMap.GetLength(1); j++)
                {
                    HiddenMap[i, j] = " ";
                    ShowedMap[i, j] = " ";
                }
            }
            HiddenMap[h.X, h.Y] = "H";
            ShowedMap[h.X, h.Y] = "H";
            int countMonsters = 0;
            for (int i = 0; i < HiddenMap.GetLength(0) && countMonsters <= 15; i++)
            {
                for (int j = 0; j < HiddenMap.GetLength(1) && countMonsters <= 15; j++)
                {
                    if (i - 1 >= 1 && j - 1 >= 1 && i + 2 < HiddenMap.GetLength(0) && j + 2 < HiddenMap.GetLength(1))
                    {
                        if (HiddenMap[i, j + 1] == " " && HiddenMap[i, j + 2] == " " && HiddenMap[i, j - 1] == " " && HiddenMap[i, j - 2] == " ")
                        {
                            if (HiddenMap[i + 1, j - 1] == " " && HiddenMap[i - 1, j - 1] == " " && HiddenMap[i + 1, j + 1] == " " && HiddenMap[i - 1, j + 1] == " ")
                            {
                                if (HiddenMap[i + 1, j] == " " && HiddenMap[i + 2, j] == " " && HiddenMap[i - 1, j] == " " && HiddenMap[i - 2, j] == " ")
                                {
                                    Random r = new Random();
                                    int rng = r.Next(15);

                                    switch (rng)
                                    {
                                        case 0:
                                        case 1:
                                        case 3:
                                        case 5:
                                            HiddenMap[i, j] = "L";
                                            countMonsters++;
                                            break;
                                        case 8:
                                            HiddenMap[i, j] = "O";
                                            countMonsters++;
                                            break;
                                        case 10:
                                            HiddenMap[i, j] = "D";
                                            countMonsters++;
                                            break; 
                                    }
                                }

                            }
                        }
                    }
                }
            }
            HiddenMap[h.X, h.Y] = "H";
        }
        public void ShowMap()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ShowedMap.GetLength(0); i++)
            {
                for (int j = 0; j < ShowedMap.GetLength(1); j++)
                {
                    sb.Append($"{ShowedMap[i, j]}|");
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb);
        }

        public void ModifyShowedMap(string modif, (int,int) newPosition)
        {
            ShowedMap[newPosition.Item1,newPosition.Item2]= modif;
        }
        public void ModifyShowedMap(string modif, (int, int) newPosition, (int, int) oldPosition)
        {
            ShowedMap[oldPosition.Item1, oldPosition.Item2] = " ";
            ShowedMap[newPosition.Item1, newPosition.Item2] = modif;
        }

        public void ModifyHiddenMap(string modif, (int, int) newPosition)
        {
            HiddenMap[newPosition.Item1, newPosition.Item2] = modif;
        }
        public void ModifyHiddenMap(string modif, (int, int) newPosition, (int, int) oldPosition)
        {
            HiddenMap[oldPosition.Item1, oldPosition.Item2] = " ";
            HiddenMap[newPosition.Item1, newPosition.Item2] = modif;
        }
        public void ModifyMaps(string modif, (int, int) newPosition)
        {
            ShowedMap[newPosition.Item1, newPosition.Item2] = modif;
            HiddenMap[newPosition.Item1, newPosition.Item2] = modif;
        }
        public void ModifyMaps(string modif, (int, int) newPosition, (int, int) oldPosition)
        {
            HiddenMap[oldPosition.Item1, oldPosition.Item2] = " ";
            HiddenMap[newPosition.Item1, newPosition.Item2] = modif;
            ShowedMap[oldPosition.Item1, oldPosition.Item2] = " ";
            ShowedMap[newPosition.Item1, newPosition.Item2] = modif;
        }

    }
}
