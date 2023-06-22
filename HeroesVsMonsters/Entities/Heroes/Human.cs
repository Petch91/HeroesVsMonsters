using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters.Entities.Heroes
{
    public class Human : Hero
    {

        protected override void GenerateStats()
        {
            base.GenerateStats();
            StatEntity[StatType.Str] += 1;
            StatEntity[StatType.Stamina] += 1;
        }
    }
}
