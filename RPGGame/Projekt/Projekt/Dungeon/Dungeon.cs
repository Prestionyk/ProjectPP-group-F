using Projekt.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Projekt
{
    public class Dungeon 
    {
        private List<Fight> fightList = new List<Fight>();
        
        public Dungeon() { }
        public static Dungeon operator +(Dungeon dungeon, Fight fight)
        {
            dungeon.fightList.Add(fight);
            return dungeon;
        }

        public void BeginFights(Player player)
        {
            for(int i = 0; i < fightList.Count; i++)
            {
                try
                {
                    fightList[i].Start(player);
                }
                catch (PlayerDeadException)
                {
                    Log.Send("");
                    Log.Send("Player has died!");
                    Thread.Sleep(3000);
                    return;
                }                
                Log.Send("");                
                if (i != fightList.Count - 1) Log.Send($"--- Fight {i + 1} Clear! ---");
                else Log.Send($"--- Dungeon Clear! ---");
                Thread.Sleep(3000);
                Log.ClearLog();   
            }
        }
    }
}
