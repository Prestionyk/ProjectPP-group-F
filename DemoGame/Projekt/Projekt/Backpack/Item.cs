
using System;

namespace Projekt
{
    class Item
    {
        protected string Name;
        public Item() {
            Name = GetType().Name;
        }
        
        public void Draw(int Position_X, int Position_Y)
        {
            Console.SetCursorPosition(Position_X, Position_Y);
            Console.Write(Name);
        }

        public void Draw(int Position_X, int Position_Y,ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Draw(Position_X, Position_Y);
            Console.ResetColor();

        }
    }
}
