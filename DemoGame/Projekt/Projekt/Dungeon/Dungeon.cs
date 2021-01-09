using System;
using System.Collections.Generic;

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

       public bool BeginFights(Player player)
        {
            foreach (Fight fight in fightList)
            {
                if (fight.Start(player))
                    return true;
            }
            return false;   
        }
    }
}