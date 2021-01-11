using Projekt.Usable;
using System;
using System.Collections.Generic;

namespace Projekt
{
    public class Player
    {
        private Menu menu = new Menu();
        private Dictionary<string,int> Stats = new Dictionary<string, int>()
        {
            { "HP" , 1 },{ "MAXHP" , 50 },{ "MP" , 30 },{ "MAXMP" , 30 },{ "STR" , 120 },{ "DEF" , 10 },{ "INT" , 8 },{ "AGI" , 11 }
        };
        private List<IUsable> Items = new List<IUsable>() { new ThrowingKnife(), new ThrowingKnife(), new HealthPotion(), new HealthPotion() };
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
            catch (ArgumentNullException) { Return = true; }
        }

        public void Attack()
        {
            try
            {
                SelectTarget(currentFight).Hurt(Stats["STR"],this);
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
            if (Stats["HP"] + Amount > Stats["MAXHP"])
                Amount = Stats["MAXHP"] - Stats["HP"];
            Stats["HP"] += Amount;                        
            menu.UpdateStat(this, "HP");
            Log.Send($"* Player recovered {Amount} HP. {Stats["HP"]} HP left.");
        }

        public void Hurt(int DMG, Enemy enemy)
        {
            DMG -= (Stats["DEF"] / 5);

            Random roll = new Random();
            bool crit = false, dodge = false;

            if (roll.Next(100) <= enemy.GetStats()[7])
            {
                DMG *= 2;
                crit = true;
            }
            if (Stats["AGI"] > enemy.GetStats()[7])
            {
                if (roll.Next(100) <= Stats["AGI"] - enemy.GetStat(7))
                {
                    DMG = 0;
                    dodge = true;
                }
            }


            if (Defending)
                DMG /= 2;

            Stats["HP"] -= DMG;

            menu.UpdateStat(this, "HP");

            if (dodge)
                Log.Send("* Atack dodged!");
            else
            {
                if (crit)
                    Log.Send("* Critical Hit!");
            }

            Log.Send($"* Player took {DMG} DMG. {Stats["HP"]} HP left.");

        }

        public bool CheckIfEnoughMP(int Amount)
        {
            if (Stats["MP"] >= Amount)
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
            Stats["MP"] -= Amount;
            menu.UpdateStat(this, "MP");


        }

        public void setCurrentFight(Fight fight)
        {
            currentFight = fight;
        }

        public List<int> GetStats()
        {
            return new List<int> { 
                Stats["HP"], Stats["MAXHP"],Stats["MP"] ,Stats["MAXMP"] ,Stats["STR"] ,Stats["DEF"] ,Stats["INT"] ,Stats["AGI"]  
            };
        }
        public int GetStat(string stat)
        {
            return Stats[stat];
        }
        public void RegenerateMP(int Amount)
        {
            if (Stats["MP"] + Amount > Stats["MAXMP"])
                Amount = Stats["MAXMP"] - Stats["MP"];
            Stats["MP"] += Amount;
            menu.UpdateStat(this, "MP");
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
            if (Stats["HP"] <= 0)
                throw new Exception("Player has died!");
        }
    }
}
