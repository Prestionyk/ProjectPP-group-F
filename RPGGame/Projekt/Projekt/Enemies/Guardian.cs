namespace Projekt
{
    class Guardian : Enemy 
    {

        public Guardian()
        {
	        sprite = @"    .----.                    " +
                     @"  _/\ ____\      _______      " +
                     @" (/  /    .     /       \     " +
                     @" /  /    /     [  ()  ]  |    " +
                     @"/  /  (\/    .-|_______-.---. " +
                     @"| /    \\_  /  /       / / '\\" +
                     @"\/____/|'.) \ (        \ ' ,'/" +
                     @"       \ \\.' -\   '    '---' " +
                     @"        \ \\  / )'|'   /   |  " +
                     @"         \ \\'  |_ _  |   /   " +
                     @"          \/\\ [_____. ' /    " +
                     @"             \\/   .'  .'\    " +
                     @"              \.-'_.'    |    " +
                     @"              (_.' ,      \   " +
                     @"              |  \\/\     |   " ;

            spriteWidth = 30;
            name = "Guardian";
            Stats["HP"] = 200;
            Stats["MAXHP"] = 200;
            Stats["STR"] = 15;
            Stats["DEF"] = 10;
            Stats["INT"] = 7;
        }

        /*public string EmptySprite()
        {
            string space = "                                " +
                           "                                " +
                           "                                " +
                           "                                " +
                           "                                " +
                           "                                " +
                           "                                " +
                           "                                " +
                           "                                " +
                           "                                " +
                           "                                " +
                           "                                " +
                           "                                " +
                           "                                " +
                           "                                ";
            return space;
        }*/


    }
}
