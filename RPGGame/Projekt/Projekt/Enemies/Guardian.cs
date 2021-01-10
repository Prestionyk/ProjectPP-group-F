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
            HP = 100;
            MAXHP = 100;
            STR = 9;
            DEF = 9;
            INT = 7;
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
