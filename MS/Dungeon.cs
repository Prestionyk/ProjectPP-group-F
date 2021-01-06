using System;
using System.Collections.Generic;

namespace ProjectGame
{
    class Dungeon 
    {
        private List<Fight> fightList = new List<Fight>();
        
        public Dungeon() { }
        public static Dungeon operator +=(Dungeon dungeon, Fight fight)
        {
            dungeon.fightList.Add(fight);
            return dungeon;
        }

       public void Enter()
        {
            foreach (Fight fight in fightList)
                Console.WriteLine(fight);
        }
    }
}