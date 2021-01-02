using System;
using System.Collections.Generic;

namespace ProjectGame
{
    class Fight
    {
        private List<EnemyInterface> enemyList = new List<EnemyInterface>();

        public Fight() { }
        public static Fight operator +(Fight fight, EnemyInterface enemy)
        {

            fight.enemyList.Add(enemy);
            return fight;
        }

        public void whosInFight()
        {
            foreach(Enemy enemy in enemyList)
            {
                Console.WriteLine(enemy.name);
            }
        }

    }
}
