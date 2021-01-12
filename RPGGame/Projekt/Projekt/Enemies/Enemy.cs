using Projekt.Usable;
using System;
using System.Collections.Generic;

namespace Projekt
{
    public abstract class Enemy : IStats
    {
        protected string name;
        protected Dictionary<string, int> Stats = new Dictionary<string, int>()
        {
            { "HP" , 100 },{ "MAXHP" , 100 },{ "MP" , 20 },{ "MAXMP" , 20 },{ "STR" , 10 },{ "DEF" , 10 },{ "INT" , 10 },{ "AGI" , 10 }
        };
        protected string sprite;
        protected int spriteWidth, posX, posY;
        protected int dropChance = 2; // czym więcej tym mniejsza szansa
        protected List<IUsable> dropList = new List<IUsable>();

        private readonly int HPBarWidth = 8;

        public List<int> GetStats()
        {
            List<int> stats = new List<int>() {
                Stats["HP"], Stats["MAXHP"],Stats["MP"] ,Stats["MAXMP"] ,Stats["STR"] ,Stats["DEF"] ,Stats["INT"] ,Stats["AGI"]
            };

            return stats;
        }
        public int GetStat(string key)
        {
            return Stats[key];
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
            player.Hurt(Calculate.HitDamage(this, player));
        }

        public void Hurt(int DMG)
        {
            Stats["HP"] -= DMG;

            if (DMG == 0)
                Log.Send($"* {GetName()} dodged the attack!");
            else if (CheckIfDied())
                Log.Send($"* {GetName()} was hit for {DMG} DMG and died.");
            else
                Log.Send($"* {GetName()} was hit for {DMG} DMG. {Stats["HP"]} HP left.");

            DrawHPBar();
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

            for (int i = 0; i < sprite.Length; i++)
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
            Console.SetCursorPosition(posX - (HPBarWidth + 2) /2 + spriteWidth / 2, posY + sprite.Length / spriteWidth + 1);            
            string bar = "[";
            for (int i = 0; i < HPBarWidth ; i++)
            {
                bar += i <= (HPBarWidth * Stats["HP"] / Stats["MAXHP"]) ? "═" : "-";
            }
            bar += "]";
            Console.Write(bar);
        }

        public void ClearSpriteAndHPBar()
        {
            Console.SetCursorPosition(posX, posY);
            for (int i = 0; i <= sprite.Length; i += spriteWidth)
            {
                Console.Write(new string(' ', spriteWidth));
                Console.SetCursorPosition(posX, posY + (i + 1) / spriteWidth);
            }
            Console.SetCursorPosition(posX - (HPBarWidth + 2) / 2 + spriteWidth / 2, posY + sprite.Length / spriteWidth + 1);
            Console.Write(new string(' ', HPBarWidth + 2));                        
        }

        public bool CheckIfDied()
        {
            if (Stats["HP"] <= 0) return true;
            else return false;
        }

        public void DropReward(Player player)
        {
            if (dropList.Count > 0)
            {
                Random roll = new Random();
                if (roll.Next(dropChance) == 0)
                    player.PickUp(dropList[roll.Next(dropList.Count)]);
            }
        }
    }
}
