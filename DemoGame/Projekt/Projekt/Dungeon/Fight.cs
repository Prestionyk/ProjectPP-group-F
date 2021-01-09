﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace Projekt
{
    public class Fight
    {
        private List<Enemy> enemyList = new List<Enemy>();
        private bool clear = false;
        private Player player;
        private int TurnCount = 0;

        public Fight() { }
        public static Fight operator +(Fight fight, Enemy enemy)
        {

            fight.enemyList.Add(enemy);
            return fight;
        }

        public List<Enemy> GetEnemyList() { return enemyList; }
        public Player GetPlayer() { return player; }

        public bool Start(Player player)
        {
            this.player = player;
            player.setCurrentFight(this);
            bool PlayerIsDead = false;
            //GlobalsVariables.CurrentFight = this;

            DrawEnemies();
            while (!clear && !PlayerIsDead)
            {
                PlayerIsDead = Turn();
                if (enemyList.Count == 0)
                    clear = true;
            }
            return PlayerIsDead;    
        }

        public bool Turn()
        {
            TurnCount++;
            Log.Send($"----- Turn {TurnCount} -----");

            player.PlayerTurn();

            for (int i = 0; i < enemyList.Count; i++)
            {
                Enemy enemy = enemyList[i];
                if (enemy.checkIfDied())
                {
                    enemy.ClearSpriteAndHPBar();
                    enemy.DropReward(player);
                    enemyList.Remove(enemy);
                    --i;
                    continue;
                }
            }

            for (int i = 0; i < enemyList.Count; i++)
            {
                Thread.Sleep(500);
                Enemy enemy = enemyList[i];
                enemy.Attack(player);
                if (player.checkIfDied()) return true;
            }
            
            Log.Send("");
            Thread.Sleep(300);
            return false;
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
