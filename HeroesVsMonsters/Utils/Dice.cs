using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters.Utils
{
    public enum DiceType
    {
        D4 =4,
        D6 = 6,
        D8 = 8,
        D10 = 10
    }
    public static class Dice
    {

        public static int Throws(DiceType nbFace)
        {
            Random rnd = new Random();
            return rnd.Next(1, (int)nbFace + 1);
        }

        public static int Throws(DiceType nbFace,int nbDice, int nbBest)
        {
            Random rnd = new Random();
            List<int> dices = new List<int>();
            for (int i = 0; i<nbDice;i++) 
            {
                dices.Add(rnd.Next(1, (int)nbFace + 1));            
            }
            return dices.OrderByDescending(x => x).Take(nbDice).Sum();
        }

    }
}
