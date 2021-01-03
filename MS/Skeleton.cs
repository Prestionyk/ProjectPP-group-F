
namespace ProjectGame
{
    class Skeleton : Enemy 
    {

        public Skeleton()
        {
            this.sprite="    ___   " +
                        "   ,o_ )  " +
                        "   "' |_  " +
                        "   _.-/)\ " +
                        "  "  ,-_/ " +
                        "   '"   ; " +
                        "       /  " +
                        "     /  \ " +
                        "   .-'  ,/" ;
            this.name = "Skeleton";
            this.HP = 30;
            this.MAXHP = 30;
            this.STR = 8;
            this.DEF = 6;
            this.INT = 3;

        }

    }
}
