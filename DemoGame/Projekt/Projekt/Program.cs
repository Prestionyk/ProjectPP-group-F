using System;

namespace Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Player player = new Player();
            Dungeon Myrtana = new Dungeon();
            Fight Round_one = new Fight();
            Skeleton Skeleton = new Skeleton();


            Round_one += Skeleton;
            Myrtana += Round_one;

            ///////////////////////////////////////////////////

            player.EnterDungeon(Myrtana);


        }
    }
}