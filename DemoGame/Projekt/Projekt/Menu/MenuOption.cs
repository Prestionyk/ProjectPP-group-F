using System;

namespace Projekt
{
    class MenuOption
    {
        private string OptionName;
        private int x, y;

        public MenuOption(string OptionName, int Position_X, int Position_Y) {
            this.OptionName = OptionName;
            x = Position_X;
            y = Position_Y;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(OptionName.ToUpper());
        }

        public string GetName()
        {
            return OptionName;
        }

        public int GetX() { return x; }
        public int GetY() { return y; }
        
    }
}
