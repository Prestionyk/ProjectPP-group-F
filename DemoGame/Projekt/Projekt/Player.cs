using System;
using System.Collections.Generic;

namespace Projekt
{
    public class Player
    {
        private Menu menu = new Menu();
        private int HP = 50, MAXHP = 50, MP = 20, MAXMP = 20, STR = 12, DEF = 10, INT = 8, AGI = 11;
        private Fight currentFight;
        private int LastSelection = 0;
        //public Enemy currentEenemy;

        public Player() {
            menu.DrawMenu();
            menu.DrawStats(this);
        }

        public void Enter(Dungeon enteredDungeon)
        {
            enteredDungeon.BeginFights(this);
        }


        public void SelectAction()
        {
            string Action = menu.SelectAction();
            
            GetType().GetMethod(Action).Invoke(this, null);
        }

        public void Attack()
        {
            try
            {
                SelectTarget(currentFight).Hurt(STR);
            }
            catch(ArgumentOutOfRangeException e) { }
        }

        public int Skill()
        {
            return 2;
        }
        public int Item()
        {
            return 3;
        }
        public int Defend()
        {
           return 4;
        }

        public Enemy SelectTarget(Fight fight)
        {
            int CurrentSelection = LastSelection;
            List<Enemy> enemyList = fight.GetEnemyList();
            if (CurrentSelection > enemyList.Count - 1)
                CurrentSelection = enemyList.Count - 1;

            while (true)
            {
                enemyList[CurrentSelection].DrawSprite(Program.HighlightColor);

                int PreviousSelection = CurrentSelection;
                switch (Controller.GetButton())
                {
                    case ConsoleKey.LeftArrow:
                        CurrentSelection--;
                        break;
                    case ConsoleKey.RightArrow:
                        CurrentSelection++;
                        break;
                    case ConsoleKey.Z:
                        LastSelection = CurrentSelection;
                        enemyList[CurrentSelection].DrawSprite();
                        return enemyList[CurrentSelection];
                }
                if (CurrentSelection < 0)
                    CurrentSelection = 0;
                if (CurrentSelection > enemyList.Count - 1)
                    CurrentSelection = enemyList.Count - 1;

                if (PreviousSelection != CurrentSelection)
                    enemyList[PreviousSelection].DrawSprite();
                   
            }            
        }

        public void Hurt(int DMG)
        {
            HP -= DMG;
            menu.UpdateHPMP(this);
            Console.SetCursorPosition(10, 26);
            Console.WriteLine($"Player was hit for {DMG} DMG. {HP} HP left."); //Powinno wysyłać do loga
        }

        public void setCurrentFight(Fight fight)
        {
            currentFight = fight;
        }

        public int[] getStats()
        {
            return new int[8] { HP, MAXHP, MP, MAXMP, STR, DEF, INT, AGI };
        }
    }
}
