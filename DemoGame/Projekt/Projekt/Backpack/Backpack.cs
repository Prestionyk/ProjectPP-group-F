using System;
using System.Collections.Generic;
using Projekt.Draw;

namespace Projekt
{
    class Backpack
    {
        private readonly int SizeX = 50, SizeY = 5;
        private readonly int PositionLeft = 15, PositionTop = 17;
        private int SelectedItem = 0;
        private int SelectedPage = 0;
        private List<Item> items = new List<Item>();
        public Backpack() {
            Add(2, new HealthPotion());
        }

        public void Add(int ilo, Item item)
        {
            for (int i = 0; i < ilo; i++)
                items.Add(item);
        }
        public void DrawBackpack()
        {

            DrawFrameMenu.Draw(PositionLeft, PositionTop, SizeX, SizeY);
            DrawBackpackContent.Draw(PositionLeft, PositionTop, SelectedPage, SelectedItem, items);
            
            while (!SelectItem())
            {  
                DrawBackpackContent.Draw(PositionLeft, PositionTop, SelectedPage, SelectedItem, items);
            }
            
        }
        public bool SelectItem()
        {
            switch (Controller.GetButton())
            {
                case ConsoleKey.LeftArrow:
                    SelectedItem -= 3;
                    break;
                case ConsoleKey.RightArrow:
                    SelectedItem += 3;
                    break;
                case ConsoleKey.UpArrow:
                    SelectedItem -= 1;
                    break;
                case ConsoleKey.DownArrow:
                    SelectedItem += 1;
                    break;
                case ConsoleKey.Z:
                    return true;

            }
            return false;
        }
    }
}
