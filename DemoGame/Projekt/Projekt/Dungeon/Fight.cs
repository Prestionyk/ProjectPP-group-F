using System;
using System.Collections.Generic;

namespace Projekt
{
    public class Fight
    {
        private List<Enemy> enemyList = new List<Enemy>();
        private bool clear = false;
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

        public void Start(Player player)
        {
            
            foreach(Enemy enemy in enemyList)
            {
                while (!enemy.checkIfDied())
                {
                    
                    player.SelectAction(enemy);

                    player.Hurt(enemy.getSTR());
                }
                Console.WriteLine($"{enemy.GetName()} defeated! ");
                Console.ReadKey();
            }
        }

    }
}
