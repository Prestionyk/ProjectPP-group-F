using System;

namespace Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Player player = new Player();

            Dungeon dungeon = new Dungeon();
            Fight Fight_1 = new Fight();
            Skeleton Skeleton = new Skeleton();
            Enemy Skeleton2 = new Skeleton();
            Enemy s = new Slime();

            Fight_1 += Skeleton;            
            Fight_1 += Skeleton2;
            Fight_1 += s;

            dungeon += Fight_1;

            ///////////////////////////////////////////////////

            player.Enter(dungeon);            


        }
    }
}