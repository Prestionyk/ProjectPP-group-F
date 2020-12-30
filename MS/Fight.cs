using System;
using System.Collections.Generic;

namespace ProjectGame
{
    class Fight
    {
        private List<Foe> enemyList = new List<Foe>();

        public Fight() { }
        public static Fight operator +(Fight fight, Foe enemy)
        {

            fight.enemyList.Add(enemy);
            return fight;
        }

        public void whosInFight()
        {
            foreach(Foe enemy in enemyList)
            {
                Console.WriteLine(enemy.name);
            }
        }

    }
}
