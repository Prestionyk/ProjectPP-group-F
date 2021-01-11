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
            Stats["HP"] = 100;
            Stats["MAXHP"] = 100;
            Stats["STR"] = 9;
            Stats["DEF"] = 9;
            Stats["INT"] = 7;
            dropChance = 0;
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
