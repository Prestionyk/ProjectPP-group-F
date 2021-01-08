using System;

namespace Projekt
{
    class Menu
    {
        private readonly int SizeX = 50, SizeY = 5;
        private readonly int PositionLeft = 15, PositionTop = 17;

        private readonly int StatMenuSizeX = 11, StatMenuSizeY = 10;
        private readonly int StatsPosLeft = 2, StatsPosTop = 12;
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
            DrawFrame(PositionLeft, PositionTop, SizeX, SizeY);

            //Wypisz opcje
            foreach (MenuOption o in menuOptions)            
                o.Draw();            

        }

        public void DrawStats(Player player)
        {
            int PosLeft = StatsPosLeft,
                PosTop = StatsPosTop;
            DrawFrame(PosLeft, PosTop, StatMenuSizeX, StatMenuSizeY);
            int[] stats = player.getStats();
            string line = "";
            PosTop--;
            for (int i = 0; i < stats.Length; i++)
            {
                PosTop += 2;
                Console.SetCursorPosition(PosLeft + 2, PosTop);
                switch (i)
                {
                    case 0:
                        line = "HP";
                        break;
                    case 2:
                        line = "MP";
                        break;
                    case 4:
                        line = "STR";
                        break;
                    case 5:
                        line = "DEF";
                        break;
                    case 6:
                        line = "INT";
                        break;
                    case 7:
                        line = "AGI";
                        break;
                }
                if (i <= 2)
                    line += string.Format(" {0, 3}/{1}", stats[i], stats[++i]);
                else                
                    line += string.Format(" {0, 5}", stats[i]);                
                Console.Write(line);
            }
        }

        public void UpdateHPMP(Player player)
        {
            int PosLeft = StatsPosLeft,
                PosTop = StatsPosTop;
            int[] stats = player.getStats();
            string line = "";
            PosTop--;
            for (int i = 0; i < 3; i++)
            {
                PosTop += 2;
                Console.SetCursorPosition(PosLeft + 2, PosTop);
                switch (i)
                {
                    case 0:
                        line = "HP";
                        break;
                    case 2:
                        line = "MP";
                        break;
                }
                line += string.Format(" {0, 3}/{1}", stats[i], stats[++i]);
                Console.Write(line);
            }
        }

        public void DrawFrame(int PositionLeft, int PositionTop, int SizeX, int SizeY)
        {
            Console.SetCursorPosition(PositionLeft, PositionTop);
            Console.Write("╔" + new string('═', SizeX) + "╗");
            for (int i = 0; i <= SizeY; i++)
            {
                Console.SetCursorPosition(PositionLeft, Console.CursorTop + 1);
                Console.Write("║");
                Console.SetCursorPosition(PositionLeft + SizeX + 1, Console.CursorTop);
                Console.Write("║");
            }
            Console.SetCursorPosition(PositionLeft, Console.CursorTop + 1);
            Console.Write("╚" + new string('═', SizeX) + "╝");
        }

        public string SelectAction()
        {
            while (true)
            {
                Console.ForegroundColor = Program.HighlightColor;
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
                        DeselectAction();
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

        public void DeselectAction()
        {
            Console.SetCursorPosition(menuOptions[SelectedOption].GetX() - 2, menuOptions[SelectedOption].GetY());
            Console.Write(" ");
            menuOptions[SelectedOption].Draw();
        }
        
    }
}
