using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters.Entities.Heroes.Heroes
{
    public class Dwarf : Hero
    {
        protected override void GenerateStats()
        {
            base.GenerateStats();
            StatEntity[StatType.Stamina] += 2;
        }
    }
}
