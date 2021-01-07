using System;
using System.Collections.Generic;

namespace Projekt
{
    public class Fight
    {
        private List<Enemy> enemyList = new List<Enemy>();
        private bool clear = false;
        private Player player;

        public Fight() { }
        public static Fight operator +(Fight fight, Enemy enemy)
        {

            fight.enemyList.Add(enemy);
            return fight;
        }

        public List<Enemy> GetEnemyList()
        {
            return enemyList;
        }

        public void Start(Player player)
        {
            this.player = player;
            player.setCurrentFight(this);
            //GlobalsVariables.CurrentFight = this;
            

            Turn();
        }

        public void Turn()
        {
            DrawEnemies();

            while (true)
            {
                player.SelectAction();              

                for (int i = 0; i < enemyList.Count; i++)
                {                    
                    Enemy enemy = enemyList[i];                    
                    enemy.Attack(player);
                    if (i == 0)
                        enemy.DrawSprite(ConsoleColor.Yellow);

                }
            }
        }

        public void DrawEnemies()
        {
            int EnemyPos = 15;
            int totalWidth = 0;
            foreach (Enemy e in enemyList)
                totalWidth += e.GetSpriteWidth();
            int DistanceBetweenEnemies = (52 - totalWidth) / (enemyList.Count + 1);

            foreach (Enemy enemy in enemyList)
            {
                EnemyPos += DistanceBetweenEnemies;
                enemy.SetPosition(EnemyPos, 15 - enemy.GetSpriteLength() / enemy.GetSpriteWidth());
                enemy.DrawSprite();
                enemy.DrawHPBar();
                EnemyPos += enemy.GetSpriteWidth() + 1;
            }

        }

    }
}
