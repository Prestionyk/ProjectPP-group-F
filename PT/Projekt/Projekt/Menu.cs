using System;

namespace Projekt
{
    class Menu
    {
        private readonly int SizeX = 50, SizeY = 5;
        private readonly int PositionLeft = 15, PositionTop = 15;
        private readonly int PaddingLeft, PaddingRight, PaddingTop, PaddingBottom;


        private int CursorPositionX, CursorPositionY;
        private int SelectedOption = 1;

        public Menu() {
            PaddingLeft = PositionLeft + SizeX / 4;
            PaddingRight = PositionLeft + SizeX - SizeX / 4 - 4;
            PaddingTop = PositionTop + SizeY / 5 + 1;
            PaddingBottom = PositionTop + SizeY - SizeY / 4 + 1;
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
            Console.SetCursorPosition(PaddingLeft, PaddingTop);
            Console.Write("ATTACK");
            Console.SetCursorPosition(PaddingLeft, PaddingBottom);
            Console.Write("ITEM");

            Console.SetCursorPosition(PaddingRight, PaddingTop);
            Console.Write("SKILL");
            Console.SetCursorPosition(PaddingRight, PaddingBottom);
            Console.Write("DEFEND");            

        }

        public string SelectAction()
        {
            while (true)
            {
                Console.SetCursorPosition(CursorPositionX, CursorPositionY);
                Console.Write(" ");

                switch (SelectedOption)
                {
                    case 1: //Attack
                        CursorPositionX = PaddingLeft;
                        CursorPositionY = PaddingTop;
                        break;
                    case 2: //Skill
                        CursorPositionX = PaddingRight;
                        CursorPositionY = PaddingTop;
                        break;
                    case 3: //Item
                        CursorPositionX = PaddingLeft;
                        CursorPositionY = PaddingBottom;
                        break;
                    case 4: //Defend
                        CursorPositionX = PaddingRight;
                        CursorPositionY = PaddingBottom;
                        break;
                }
                CursorPositionX -= 2; //Offset by się strzałka pojawiła obok opcji

                Console.SetCursorPosition(CursorPositionX, CursorPositionY);
                Console.Write(">");

                int previousSelection = SelectedOption;
                switch (Controller.GetButton())
                {
                    case ConsoleKey.LeftArrow:
                        if (SelectedOption != 3)
                            SelectedOption--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (SelectedOption != 2)
                            SelectedOption++;
                        break;
                    case ConsoleKey.UpArrow:
                        SelectedOption -= 2;
                        break;
                    case ConsoleKey.DownArrow:
                        SelectedOption += 2;
                        break;

                    case ConsoleKey.Z: //Potwierdzenie wyboru
                        switch (SelectedOption)
                        {
                            case 1:
                                return "Attack";
                            case 2:
                                return "Skill";
                            case 3:
                                return "Item";
                            case 4:
                                return "Defend";
                        }

                        break;
                }

                if (SelectedOption < 1 || SelectedOption > 4)
                    SelectedOption = previousSelection;
            }
        }

        
    }
}
