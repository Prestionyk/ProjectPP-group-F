using System;
using System.Collections.Generic;

namespace Projekt
{
    public class Enemy 
    {
        protected string name;
        protected int HP=100, MAXHP=100, MP=20, MAXMP=20, STR=10, DEF=10, INT=10, AGI=10;
        protected string sprite;
        protected int spriteWidth, posX, posY;
        
        public List<int> GetStats()
        {
            List<int> stats = new List<int>() {
                HP, MAXHP, MP, MAXMP, STR, DEF, INT, AGI
            };

            return stats;
        }
        public string GetName()
        {
            return name;
        }        

        public int GetSpriteLength()
        {
            return sprite.Length;
        }
        public int GetSpriteWidth()
        {
            return spriteWidth;
        }

        public void Attack(Player player)
        {
            player.Hurt(STR);
        }

        public void Hurt(int DMG)
        {
            HP -= DMG;
            DrawHPBar();
            Console.SetCursorPosition(10, 25);
            Console.WriteLine($"{GetName()} was hit for {DMG} DMG. {HP} HP left.");
        }

        public void SetPosition(int Position_X, int Position_Y)
        {
            posX = Position_X;
            posY = Position_Y;
        }

        public void DrawSprite(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            DrawSprite();
            Console.ResetColor();
        }

        public void DrawSprite()
        {           
            Console.SetCursorPosition(posX, posY);
            string SpriteLine = "";
            
            for(int i = 0; i < sprite.Length; i++)
            {
                SpriteLine += sprite[i];
                if (SpriteLine.Length == spriteWidth)
                {
                    Console.Write(SpriteLine);
                    Console.SetCursorPosition(posX, posY + (i + 1) / spriteWidth);
                    SpriteLine = "";
                }
            }
        }        

        public void DrawHPBar()
        {
            int Width = 8;
            Console.SetCursorPosition(posX - (Width + 2) /2 + spriteWidth / 2, posY + sprite.Length / spriteWidth + 1);            
            string bar = "[";
            for (int i = 0; i < Width ; i++)
            {
                bar += i <= (Width * HP / MAXHP) ? "═" : "-";
            }
            bar += "]";
            Console.Write(bar);
        }

        public bool checkIfDied()
        {
            if (HP <= 0) return true;
            else return false;
        }

        /*public int getSTR()
        {
            return STR;
        }*/
    }
}
