using System;

namespace Projekt
{
    public class Player
    {
        private Menu menu = new Menu();
        private int HP = 50, MAXHP = 50, MP = 20, MAXMP = 20, STR = 12, DEF = 10, INT = 8, AGI = 11;
        private Fight currentFight;
        //public Enemy currentEenemy;

        public Player() {
            //GlobalsVariables.player = this;
            menu.DrawMenu();
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
            currentFight.GetEnemyList()[0].Hurt(STR);
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

        public void Hurt(int DMG)
        {
            HP -= DMG;
            Console.SetCursorPosition(10, 26);
            Console.WriteLine($"Player was hit for {DMG} DMG. {HP} HP left.");
        }

        public void setCurrentFight(Fight fight)
        {
            currentFight = fight;
        }
    }
}
