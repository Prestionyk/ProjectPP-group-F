using System;

namespace Projekt
{
    static class RefreshField
    {

        public static void EmptySprite()
        {
            string clear = "";
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i <= 16; i++)
            {
                for (int x = 0; x <= 80; x++)
                    clear += " ";
                clear += "\n";
            }
            Console.Write(clear);
        }
    }
}
