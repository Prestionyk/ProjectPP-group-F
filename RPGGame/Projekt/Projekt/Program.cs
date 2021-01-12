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
            Fight Fight_3 = new Fight();

            Fight_1 += new Slime();
            Fight_1 += new Slime();
            Fight_1 += new Slime();

            Fight_2 += new Skeleton();
            Fight_2 += new Skeleton();
            Fight_2 += new Slime();

            Fight_3 += new Guardian();

            dungeon += Fight_1;
            dungeon += Fight_2;
            dungeon += Fight_3;

            ///////////////////////////////////////////////////

            player.Enter(dungeon);            

        }
    }
}