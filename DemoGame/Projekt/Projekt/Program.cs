using System;

namespace Projekt
{
    class Program
    {        
        public static readonly ConsoleColor HighlightColor = ConsoleColor.Yellow;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Player player = new Player();

            Dungeon dungeon = new Dungeon();
            Fight Fight_1 = new Fight();
            Fight Fight_2 = new Fight();
            Skeleton Skeleton = new Skeleton();
            Skeleton Skeleton2 = new Skeleton();
            Slime s = new Slime();
            Guardian guardian = new Guardian();

            Fight_1 += Skeleton;            
            Fight_1 += Skeleton2;
            Fight_1 += s;
            Fight_2 += guardian;

            dungeon += Fight_1;
            dungeon += Fight_2;
            ///////////////////////////////////////////////////

            player.Enter(dungeon);            


            Console.ReadKey();
        }
    }
}