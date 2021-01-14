using Projekt.Exceptions;
using Projekt.Usable;
using System;
using System.Collections.Generic;

namespace Projekt
{
    class Menu
    {
        public static readonly ConsoleColor HighlightColor = ConsoleColor.Yellow;

        private readonly int SizeX = 50, SizeY = 4;
        private readonly int PositionLeft = 15, PositionTop = 17;

        private readonly int StatMenuSizeX = 11, StatMenuSizeY = 10;
        private readonly int StatsPosLeft = 2, StatsPosTop = 11;
        //private readonly int PaddingLeft, PaddingRight, PaddingTop, PaddingBottom;
        private List<MenuOption> menuOptions = new List<MenuOption>();

        //private int CursorPositionX, CursorPositionY;
        private int SelectedOption = 0;

        public Menu() {
            int PaddingLeft = PositionLeft + SizeX / 4;
            int PaddingRight = PositionLeft + SizeX - SizeX / 4 - 4;
            int PaddingTop = PositionTop + SizeY / 5 + 2;
            int PaddingBottom = PositionTop + SizeY - SizeY / 4 + 1;

            menuOptions.Add(new MenuOption("Attack", PaddingLeft, PaddingTop));            
            menuOptions.Add(new MenuOption("Skill", PaddingRight, PaddingTop));
            menuOptions.Add(new MenuOption("Item", PaddingLeft, PaddingBottom));
            menuOptions.Add(new MenuOption("Defend", PaddingRight, PaddingBottom));

            // Narysuj obramówke menu 
            DrawFrame(PositionLeft, PositionTop, SizeX, SizeY);
            // Narysuj obramówke loga
            DrawFrame(PositionLeft + SizeX + 2, 0, 44, 21);
        }

        public void DrawMenu()
        {
            ClearMenu();
            //Wypisz opcje
            foreach (MenuOption o in menuOptions)            
                o.Draw();
        }

        public int DrawUsable(List<IUsable> list)
        {
            ClearMenu(); //Wyczyść opcje które wcześniej tam były
            List<MenuOption> options = new List<MenuOption>();
            int PosLeft = PositionLeft,
                PosTop = PositionTop;
            PosLeft += SizeX / 6 - 20;
            PosTop++;
            foreach (IUsable i in list)     //Stwórz MenuOption dla każdego itemu
            {

                PosLeft += 20;
                if (PosLeft > PositionLeft + 30)
                {
                    PosTop += 2;
                    PosLeft = PositionLeft + SizeX / 6;
                }
                options.Add(new MenuOption(i.GetName(), PosLeft, PosTop));
                options[options.Count - 1].Draw();      //Wypisz każdą z tych opcji
            }

            SelectedOption = 0;
            return int.Parse(SelectAction(options, 2, true));
        }

        public void ClearMenu()
        {

            for (int i = 0; i <= SizeY; i++)
            {
                Console.SetCursorPosition(PositionLeft + 1, PositionTop + 1 + i);
                Console.Write(new string(' ', SizeX));
            }
        }

        public void DrawStats(Player player)
        {
            int PosLeft = StatsPosLeft,
                PosTop = StatsPosTop;
            DrawFrame(PosLeft, PosTop, StatMenuSizeX, StatMenuSizeY);
            List<int> stats = player.GetStats();
            string line = "";
            PosTop--;
            for (int i = 0; i < stats.Count; i++)
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

        public void UpdateStat(Player player, string stat)
        {
            int PosLeft = StatsPosLeft,
                PosTop = StatsPosTop;
            PosTop--;
            int index = 0 ;
            switch (stat)
            {
                case "HP":
                    index = 0;
                    break;
                case "MP":
                    index = 1;
                    break;
            }
            PosTop += 2 * (index+1);

            Console.SetCursorPosition(PosLeft + 2 + 3, PosTop);
            if (stat == "HP" || stat == "MP")
                Console.Write(string.Format("{0, 3}/{1}", player.GetStat(stat), player.GetStat("MAX"+stat)));            
            else
                Console.Write(string.Format(" {0, 5}", player.GetStat(stat)));
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

        public string SelectAction() { return SelectAction(menuOptions, 2, false); }

        public string SelectAction(List<MenuOption> menuOptions, int ListWidth, bool ReturnIndex)
        {
            SelectedOption = 0;
            while (true)
            {
                Console.ForegroundColor = HighlightColor;
                Console.SetCursorPosition(menuOptions[SelectedOption].GetX()-2, menuOptions[SelectedOption].GetY());
                Console.Write(">");
                menuOptions[SelectedOption].Draw();
                Console.ResetColor();

                int previousSelection = SelectedOption;
                switch (Controller.GetButton())
                {
                    case ConsoleKey.LeftArrow:
                        if (SelectedOption % ListWidth != 0)
                            SelectedOption--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (SelectedOption % ListWidth - 1 != 0)
                            SelectedOption++;
                        break;
                    case ConsoleKey.UpArrow:
                        SelectedOption -= ListWidth;
                        break;
                    case ConsoleKey.DownArrow:
                        SelectedOption += ListWidth;
                        break;

                    case ConsoleKey.Z: //Potwierdzenie wyboru
                        /*if (menuOptions == this.menuOptions)
                            DeselectAction();*/
                        DrawMenu();
                        if (!ReturnIndex)
                            return menuOptions[SelectedOption].GetName();
                        else                            
                            return SelectedOption.ToString();
                    case ConsoleKey.X:
                        throw new NoChoiceException();

                }

                if (SelectedOption < 0 || SelectedOption > menuOptions.Count-1)
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
