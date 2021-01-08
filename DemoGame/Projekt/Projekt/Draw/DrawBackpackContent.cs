using System;
using System.Collections.Generic;

namespace Projekt.Draw
{
    static class DrawBackpackContent
    {

        public static void Draw(int PositionLeft, int PositionTop,int selectedPage,int SelectedItem, List<Item> items)
        {

            Item[,] page = new Item[((items.Count-1) / 6) + 1, 6];
            int site = 0;
            int quant = 0;
            //dodanie do ''stron''
            foreach (Item it in items)
            {

                page[site, quant] = it;
                quant++;
                if (quant == 6)
                {
                    quant = 0;
                    ++site;
                }
            }

            //wyświetlanie
            int x = PositionLeft + 5;
            int y = PositionTop + 1;

            for (int i = 0; i < 6; i++)
            {
                if (y > (PositionTop + 5))
                {
                    x += 25;
                    y = PositionTop + 1;
                }
                if (page[selectedPage, i] != null)
                    if(i == SelectedItem)
                        page[selectedPage, i].Draw(x, y, Program.HighlightColor);
                    else page[selectedPage, i].Draw(x, y);

                y += 2;
            }

        }

    }
}
