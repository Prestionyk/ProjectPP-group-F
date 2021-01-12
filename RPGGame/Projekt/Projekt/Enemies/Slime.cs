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

          /*sprite =  "    _-----___    " +
                      "  .'         '-  " +
                     @" /  ()    ()   \ " +
                     @".     .___.     ." +                     
                     @"\._____________.'";*/

            sprite = "    _-----_    " +
                     "  .        '-  " +
                    @" ' ()    ()  ` " +
                    @"'    .___.    ." +
                    @"\.___________.'";

            spriteWidth = 15;
            name = "Slime";
            Stats["HP"] = 20;
            Stats["MAXHP"] = 20;
            Stats["STR"] = 9;
            Stats["DEF"] = 10;
            Stats["INT"] = 4;
            dropList.Add(new HealthPotion());
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
