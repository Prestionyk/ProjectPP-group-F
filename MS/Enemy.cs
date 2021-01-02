using System.Collections.Generic;

namespace ProjectGame
{
    public class Enemy 
    {
        protected string name;
        protected int HP=100, MAXHP=100, MP=20, MAXMP=20, STR=10, DEF=10, INT=10, AGI=10;
        
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

        public void attack(Enemy attacker/*, Player player*/)
        {

        }

        public bool checkIfDied()
        {
            if (HP <= 0) return true;
            else return false;
        }
    }
}