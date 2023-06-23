using HeroesVsMonsters.Entities;
using HeroesVsMonsters.Entities.Heroes;
using HeroesVsMonsters.Entities.Monsters;
using HeroesVsMonsters.Utils;

Human dante = new Human("Dante");
List<Monster> monsters = new List<Monster>();


for (int i = 0; i < 100; i++)
{
    Random r = new Random();
    int rng = r.Next(6);

    switch (rng)
    {
        case 0:
        case 1:
        case 2:
            Wolf wolf = new Wolf();
            wolf.DieEvent += dante.DieAction;
            monsters.Add(wolf);
            break;
        case 3:
        case 4:
            Orc orc = new Orc();
            orc.DieEvent += dante.DieAction;
            monsters.Add(orc);
            break;
        case 5:
            Dragon dragon = new Dragon();
            dragon.DieEvent += dante.DieAction;
            monsters.Add(dragon);
            break;
    }
}

while (dante.IsAlive() && monsters.Count > 1)
{
    for (int i = 0; i < monsters.Count && dante.IsAlive(); i++)
    {
       Game.Fight(dante, monsters[i]);
    }
}

if (dante.IsAlive())
{
    Console.WriteLine("You win");
}
else
{
    Console.WriteLine("You loose");
}

