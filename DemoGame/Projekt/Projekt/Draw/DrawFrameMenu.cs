using System;

namespace Projekt.Draw
{
    static class DrawFrameMenu
    {
        public static void Draw(int PositionLeft, int PositionTop, int SizeX, int SizeY)
        {
            Console.SetCursorPosition(PositionLeft, PositionTop);
            Console.Write("╔" + new string('═', SizeX) + "╗");
            for (int i = 0; i <= SizeY; i++)
            {
                Console.SetCursorPosition(PositionLeft, Console.CursorTop + 1);
                Console.Write("║" + new string(' ', SizeX) + "║");
            }
            Console.SetCursorPosition(PositionLeft, Console.CursorTop + 1);
            Console.Write("╚" + new string('═', SizeX) + "╝");

        }
    }
}
