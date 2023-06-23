using HeroesVsMonsters.Entities;
using HeroesVsMonsters.Entities.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters.Utils
{
    public static class Game
    {
        public static void Fight(Hero fighter1, Entity fighter2)
        {
            Console.WriteLine($"{fighter2.Name} vous attaque, soyez prêt!");
            while (fighter1.IsAlive() && fighter2.IsAlive())
            {
                
                ShowMenuFight(fighter1);
                switch (choix)
                {
                    case 1: fighter1.Attack(fighter2);
                        break;
                    case 2: fighter1.UseSkill(fighter2);
                        break;
                    case 3: fighter1.Heal();
                        break;
                    case 4: throw new NotImplementedException();
                }
                fighter1.Attack(fighter2);
                if (fighter2.IsAlive())
                {
                    fighter2.Attack(fighter1);
                }
            }
            if (!fighter2.IsAlive())
            {
                foreach (ItemType item in fighter1.Sac.Items.Keys)
                {
                    Console.WriteLine($"{item} : {fighter1.Sac[item]} ");
                }
            }
        }

        private static void ShowMenuFight(Hero fighter1,int cursorPosi)
        {
            //(int, int) cursorPosi = (0, 0);
            
            while (true)
            {
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
        }
        private static void SelectAction()
        {
            
        }
    }
}
