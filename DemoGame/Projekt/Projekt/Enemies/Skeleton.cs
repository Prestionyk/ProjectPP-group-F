
namespace Projekt
{
    class Skeleton : Enemy 
    {

        public Skeleton()
        {
            sprite =  "  ___   " +
                      " ,o_ )  " +
                      " \"' |_  " +
                     @" _.-/)\ " +
                      "\"  ,-_/ " +
                      " '\"   ; " +
                      "     /  " +
                     @"   /  \ " +
                      " .-'  ,/" ;
            spriteWidth = 8;
            name = "Skeleton";
            HP = 70;
            MAXHP = 70;
            STR = 5;
            DEF = 6;
            INT = 3;
            
        }

       /* public string EmptySprite()
        {
            string space = "        " +
                           "        " +
                           "        " +
                           "        " +
                           "        " +
                           "        " +
                           "        " +
                           "        " +
                           "        ";
            return space;
        }*/

    }
}
