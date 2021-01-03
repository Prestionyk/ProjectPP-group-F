using System;
using System.Reflection;

namespace Projekt
{
    class Player
    {
        private Menu menu = new Menu();
        private int HP = 50, MAXHP = 50, MP = 20, MAXMP = 20, STR = 12, DEF = 10, INT = 8, AGI = 11;


        public Player() {
            menu.DrawMenu();
        }

        public void SelectAction()
        {
            string Action = menu.SelectAction();

            GetType().GetMethod(Action).Invoke(this, null);
        }


        public void Attack()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Attack");
        }

        public void Skill()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Skill    ");
        }

        public void Item()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Item     ");
        }

        public void Defend()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Defend");
        }
    }
}
