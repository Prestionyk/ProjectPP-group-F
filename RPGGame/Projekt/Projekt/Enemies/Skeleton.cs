
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
            Stats["HP"] = 70;
            Stats["MAXHP"] = 70;
            Stats["STR"] = 5;
            Stats["DEF"] = 6;
            Stats["INT"] = 3;


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
