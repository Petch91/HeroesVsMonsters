namespace HeroesVsMonsters.Entities
{

    public enum StatType
    {
        Hp,
        CurrentHp,
        Str,
        Stamina
    }
    public class Stats
    {
        public Dictionary<StatType, int> StatsD = new Dictionary<StatType, int>();

        public int this[StatType stat]
        {
            get
            {
                if (!StatsD.ContainsKey(stat))
                {
                    StatsD.Add(stat, 0);
                }
                return StatsD[stat];
            }
            set
            {
                if (!StatsD.ContainsKey(stat))
                {
                    StatsD.Add(stat, 0);
                }
                StatsD[stat] = value;
            }

        }
    }
}