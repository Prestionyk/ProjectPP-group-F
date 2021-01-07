using System;

namespace Projekt
{
    class Menu
    {
        private readonly int SizeX = 50, SizeY = 5;
        private readonly int PositionLeft = 15, PositionTop = 17;
        //private readonly int PaddingLeft, PaddingRight, PaddingTop, PaddingBottom;
        private MenuOption[] menuOptions = new MenuOption[4];

        //private int CursorPositionX, CursorPositionY;
        private int SelectedOption = 0;

        public Menu() {
            int PaddingLeft = PositionLeft + SizeX / 4;
            int PaddingRight = PositionLeft + SizeX - SizeX / 4 - 4;
            int PaddingTop = PositionTop + SizeY / 5 + 1;
            int PaddingBottom = PositionTop + SizeY - SizeY / 4 + 1;

            menuOptions[0] = new MenuOption("Attack", PaddingLeft, PaddingTop);
            menuOptions[1] = new MenuOption("Skill", PaddingRight, PaddingTop);
            menuOptions[2] = new MenuOption("Item", PaddingLeft, PaddingBottom);
            menuOptions[3] = new MenuOption("Defend", PaddingRight, PaddingBottom);
        }

        public void DrawMenu()
        {        
            // Narysuj obramówke menu
            Console.SetCursorPosition(PositionLeft, PositionTop);
            Console.Write("╔" + new string('═', SizeX) + "╗");
            for (int i = 0; i <= SizeY; i++)
            {
                Console.SetCursorPosition(PositionLeft, Console.CursorTop + 1);
                Console.Write("║");
                Console.SetCursorPosition(PositionLeft + SizeX+1, Console.CursorTop);
                Console.Write("║");
            }
            Console.SetCursorPosition(PositionLeft, Console.CursorTop + 1);
            Console.Write("╚" + new string('═', SizeX) + "╝");

            //Wypisz opcje
            foreach (MenuOption o in menuOptions)            
                o.Draw();            

        }

        public string SelectAction()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(menuOptions[SelectedOption].GetX()-2, menuOptions[SelectedOption].GetY());
                Console.Write(">");
                menuOptions[SelectedOption].Draw();
                Console.ResetColor();

                /*Console.SetCursorPosition(menuOptions[SelectedOption].GetX()-1, menuOptions[SelectedOption].GetY());
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(" ");
                menuOptions[SelectedOption].Draw();
                Console.Write(" ");
                Console.ResetColor();*/

                int previousSelection = SelectedOption;
                switch (Controller.GetButton())
                {
                    case ConsoleKey.LeftArrow:
                        if (SelectedOption != 2)
                            SelectedOption--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (SelectedOption != 1)
                            SelectedOption++;
                        break;
                    case ConsoleKey.UpArrow:
                        SelectedOption -= 2;
                        break;
                    case ConsoleKey.DownArrow:
                        SelectedOption += 2;
                        break;

                    case ConsoleKey.Z: //Potwierdzenie wyboru
                        return menuOptions[SelectedOption].GetName();                        
                }

                if (SelectedOption < 0 || SelectedOption > 3)
                    SelectedOption = previousSelection;


                /*Console.SetCursorPosition(menuOptions[previousSelection].GetX() - 1, menuOptions[previousSelection].GetY());
                Console.Write(" ");
                menuOptions[previousSelection].Draw();
                Console.Write(" ");*/
                Console.SetCursorPosition(menuOptions[previousSelection].GetX() - 2, menuOptions[previousSelection].GetY());
                Console.Write(" ");
                menuOptions[previousSelection].Draw();
            }
        }

        
    }
}
