
namespace ProjectGame
{
    class Skeleton : Enemy 
    {

        public Skeleton(string name, int HP, int MAXHP, int MP, int MAXMP, int STR, int DEF, int INT, int AGI)
        {
            this.name = name;
            this.HP = HP;
            this.MAXHP = MAXHP;
            this.MP = MP;
            this.MAXMP = MAXMP;
            this.STR = STR;
            this.DEF = DEF;
            this.INT = INT;
            this.AGI = AGI;

        }

    }
}
