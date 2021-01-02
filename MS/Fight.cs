using System;
using System.Collections.Generic;

namespace ProjectGame
{
    class Fight
    {
        private List<Enemy> enemyList = new List<Enemy>();

        public Fight() { }
        public static Fight operator +(Fight fight, Enemy enemy)
        {

            fight.enemyList.Add(enemy);
            return fight;
        }

        public void whosInFight()
        {
            foreach(Enemy enemy in enemyList)
            {
                Console.WriteLine(enemy.GetName());
            }
        }

    }
}
