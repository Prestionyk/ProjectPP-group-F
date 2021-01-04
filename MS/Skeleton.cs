
namespace ProjectGame
{
    class Skeleton : Enemy 
    {

        public Skeleton()
        {
            this.sprite="    ___   " +
                        "   ,o_ )  " +
                        "   \"' |_  " +
                        "   _.-/)\\ " +
                        "  \"  ,-_/ " +
                        "   '\"   ; " +
                        "       /  " +
                        "     /  \\ " +
                        "   .-'  ,/" ;
            this.name = "Skeleton";
            this.HP = 70;
            this.MAXHP = 70;
            this.STR = 5;
            this.DEF = 6;
            this.INT = 3;

        }

    }
}
