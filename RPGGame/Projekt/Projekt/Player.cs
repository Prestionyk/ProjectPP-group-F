using Projekt.Usable;
using System;
using System.Collections.Generic;

namespace Projekt
{
    public class Player
    {
        private Menu menu = new Menu();        
        private int HP = 50, MAXHP = 50, MP = 30, MAXMP = 30, STR = 12, DEF = 10, INT = 8, AGI = 11;
        private List<IUsable> Items = new List<IUsable>() { new ThrowingKnife(), new HealthPotion(), new ThrowingKnife(), new HealthPotion() };
        private List<IUsable> Skills = new List<IUsable>() { new Heal(), new CrossSlash(), new Fireball(), new ElectricPulse(), new WaterSpear()};
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
            RegenerateMP(3);

            if (Defending)
            {
                RegenerateMP(5);
                Log.Send("Player recovered some MP from Defending!");
                Defending = false;
            }

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
            catch (NullReferenceException) { Return = true; }
        }

        public void Attack()
        {
            try
            {
                SelectTarget(currentFight).Hurt(STR,this);
            }
            catch(NullReferenceException) { Return = true; }
        }

        public void Skill()
        {
            try
            {
                int index = int.Parse(menu.DrawUsable(Skills));
                Skills[index].Use(currentFight);
                
            }
            catch (ArgumentNullException) { Return = true; }
            catch (NullReferenceException) { Return = true; }

        }
        public void Item()
        {
            
            try
            {
                int index = int.Parse(menu.DrawUsable(Items));
                Items[index].Use(currentFight);
                Items.RemoveAt(index);                
            }
            catch (ArgumentNullException) { Return = true; }
            catch (NullReferenceException) { Return = true; }            

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
            Log.Send($"* Player recovered {Amount} HP. {HP} HP left.");
        }

        public void Hurt(int DMG, Enemy enemy)
        {
            DMG -= (DEF / 5);

            Random roll = new Random();
            bool crit = false, dodge = false;

            if (roll.Next(100) <= enemy.GetStats()[7])
            {
                DMG *= 2;
                crit = true;
            }
            if (AGI > enemy.GetStats()[7])
            {
                if (roll.Next(100) <= AGI - enemy.GetStat(7))
                {
                    DMG = 0;
                    dodge = true;
                }
            }


            if (Defending)
                DMG /= 2;

            HP -= DMG;

            menu.UpdateStat(this, 0);

            if (dodge)
                Log.Send("* Atack dodged!");
            else
            {
                if (crit)
                    Log.Send("* Critical Hit!");
            }

            Log.Send($"* Player took {DMG} DMG. {HP} HP left.");

        }

        public bool CheckIfEnoughMP(int Amount)
        {
            if (MP >= Amount)
            {
                return true;
            }
            else
            {
                Log.Send($"Not enought MP to use skill.");
                Return = true;
                return false;
            }
        }

        public void DrainMana(int Amount)
        {           
            MP -= Amount;
            menu.UpdateStat(this, 2);
                        
        }

        public void setCurrentFight(Fight fight)
        {
            currentFight = fight;
        }

        public List<int> GetStats()
        {
            return new List<int> { 
                HP, MAXHP, MP, MAXMP, STR, DEF, INT, AGI 
            };
        }
        public int GetStat(int index)
        {
            return GetStats()[index];
        }
        public void RegenerateMP(int Amount)
        {
            if (MP + Amount > MAXMP)
                Amount = MAXMP - MP;
            MP += Amount;
            menu.UpdateStat(this,2);
        }
        public void PickUp(IUsable item)
        {
            if(Items.Count == 6)
            {
                Log.Send("* Inventory is full.");
            }

            else 
            {
                Log.Send($"* Obtained a {item.GetName()}");
                Items.Add(item);
            } 
        }

        public void checkIfDied()
        {
            if (HP <= 0)
                throw new Exception("Player has died!");
        }
    }
}
