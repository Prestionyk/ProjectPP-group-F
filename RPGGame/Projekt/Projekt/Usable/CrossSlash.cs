﻿
using Projekt.Usable;
using System.Threading;

namespace Projekt
{
    class CrossSlash : IUsable
    {
        private readonly string Name;
        private readonly int ManaCost = 12;
        public CrossSlash()
        {
            Name = "Cross Slash [12 MP]";
        }
        public string GetName() { return Name; }

        public void Use(Fight fight)
        {
            Player player = fight.GetPlayer();
            if (player.CheckIfEnoughMP(ManaCost))
            {
                player.DrainMana(ManaCost);
                foreach (Enemy e in fight.GetEnemyList())
                {
                    e.Hurt(Calculate.HitDamage(player, e, 100, false));
                    Thread.Sleep(300);
                }
            }
        }
    }
}