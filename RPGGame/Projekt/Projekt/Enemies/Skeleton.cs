
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
            Stats["STR"] = 10;
            Stats["DEF"] = 6;
            Stats["INT"] = 3;
            dropList.Add(new ThrowingKnife());

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
