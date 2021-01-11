namespace Projekt
{
    class Slime : Enemy 
    {

        public Slime()
        {
          /*sprite =  "       _______       " +
                      "   _.-'       '-._   " +
                      " -'   ()     ()   '- " +
                     @"/      _______      \" +
                     @"\___________________/" ;*/

            sprite =  "    _-----___    " +
                      "  .'         '-  " +
                     @" /  ()    ()   \ " +
                     @".     .___.     ." +                     
                     @"\._____________.'";

            spriteWidth = 17;
            name = "Slime";
            Stats["HP"] = 20;
            Stats["MAXHP"] = 20;
            Stats["STR"] = 3;
            Stats["DEF"] = 2;
            Stats["INT"] = 4;
            dropChance = 4;
        }

        /*public string EmptySprite()
        {
            string space = "                     " +
                           "                     " +
                           "                     " +
                           "                     " +
                           "                     ";
            return space;
        }*/

    }
}
