using System;

namespace Projekt
{
    public class Player
    {
        private Menu menu = new Menu();
        private int HP = 50, MAXHP = 50, MP = 20, MAXMP = 20, STR = 12, DEF = 10, INT = 8, AGI = 11;
        public Enemy currentEenemy;

        public Player() {
            menu.DrawMenu();
        }

        public void EnterDungeon(Dungeon enteredDungeon)
        {
            enteredDungeon.Enter(this);
        }
        public void SelectAction(Enemy enemy)
        {
            string Action = menu.SelectAction();

            GetType().GetMethod(Action).Invoke(this, new object[] { enemy });
        }

        public void Attack(Enemy enemy)
        {
            enemy.Hurt(STR);   
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
            Console.WriteLine($"Pleyer hitt by {DMG}. {HP} HP left.");
        }
    }
}
