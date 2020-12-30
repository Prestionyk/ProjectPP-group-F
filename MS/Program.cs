using System;

namespace ProjectGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Foe Slime = new Foe("Slime");
            Foe Skeleton = new Foe("Skeleton");
            Foe Spider = new Foe("Spider");

            Fight Round_one = new Fight();

            Round_one += Slime;
            Round_one += Skeleton;
            Round_one += Spider;

            Round_one.whosInFight();
        }
    }
}
