using Projekt.Usable;
using System;
using System.Collections.Generic;

namespace Projekt
{
    public class Player
    {
        private Menu menu = new Menu();        
        private int HP = 50, MAXHP = 50, MP = 20, MAXMP = 20, STR = 12, DEF = 10, INT = 8, AGI = 11;
        private List<IUsable> Items = new List<IUsable>() { new ThrowingKnife(), new HealthPotion(), new ThrowingKnife(), new HealthPotion() };
        private List<IUsable> Skills = new List<IUsable>() { new Fireball(), new ElectricPulse(), new WaterSpear() };
        private Fight currentFight;
        private int LastSelection = 0;

        private bool Defending, Return;
        //public Enemy currentEenemy;

        public Player() {
            menu.DrawMenu();
            menu.DrawStats(this);
        }

        public void Enter(Dungeon enteredDungeon)
        {
            enteredDungeon.BeginFights(this);
        }

        public void PlayerTurn()
        {
            RegenerateMP();

            if (Defending)
                Defending = false;

            do
            {
                Return = false;
                SelectAction();                
            }
            while (Return);
            
        }

        public void SelectAction()
        {
            menu.DrawMenu();
            string Action = menu.SelectAction();
            try
            {
                GetType().GetMethod(Action).Invoke(this, null);
            }
            catch (Exception) { Return = true; }
        }

        public void Attack()
        {
            try
            {
                SelectTarget(currentFight).Hurt(STR);
            }
            catch(Exception) { Return = true; }
        }

        public void Skill()
        {
            try
            {
                int index = int.Parse(menu.DrawUsable(Skills));
                Skills[index].Use(currentFight);
                
            }
            catch (Exception) { Return = true; }
        }
        public void Item()
        {
            
            try
            {
                int index = int.Parse(menu.DrawUsable(Items));
                Items[index].Use(currentFight);
                Items.RemoveAt(index);                
            }
            catch (Exception) { Return = true; }

        }
        public void Defend()
        {
            Defending = true;
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
                    case ConsoleKey.X:
                        enemyList[CurrentSelection].DrawSprite();
                        return null;
                }
                if (CurrentSelection < 0)
                    CurrentSelection = 0;
                if (CurrentSelection > enemyList.Count - 1)
                    CurrentSelection = enemyList.Count - 1;

                if (PreviousSelection != CurrentSelection)
                    enemyList[PreviousSelection].DrawSprite();
                   
            }            
        }

        public void Heal(int Amount)
        {
            if (HP + Amount > MAXHP)
                Amount = MAXHP - HP;
            HP += Amount;                        
            menu.UpdateStat(this, 0);
            Log.Send($"Player recovered {Amount} HP. {HP} HP left.");
        }

        public void Hurt(int DMG)
        {
            if (Defending)
                DMG = 0;
            HP -= DMG;
            menu.UpdateStat(this, 0);            
            Log.Send($"Player took {DMG} DMG. {HP} HP left.");
            
        }

        public bool DrainMana(int Amount)
        {
            if (MP >= Amount)
            {
                MP -= Amount;
                menu.UpdateStat(this, 2);
                Log.Send($"Player used skill. {MP} MP left.");
                return true;
            }
            else
            {
                Log.Send($"Not enought MP to use skill.");
            }
            return false;
        }

        public void setCurrentFight(Fight fight)
        {
            currentFight = fight;
        }

        public int[] getStats()
        {
            return new int[8] { HP, MAXHP, MP, MAXMP, STR, DEF, INT, AGI };
        }
        public int getStat(int index)
        {
            switch (index)
            {
                case 0: return HP;
                case 1: return MAXHP;
                case 2: return MP;
                case 3: return MAXMP;
                case 4: return STR;
                case 5: return DEF;
                case 6: return INT;
            }
            return 0;
        }

        public void RegenerateMP()
        {
            MP += 3;
            if (MP > MAXMP)
                MP = MAXMP;
            menu.UpdateStat(this,2);
        }

        public void PickUp(IUsable item)
        {
            Items.Add(item);
        }
    }
}
