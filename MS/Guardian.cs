namespace ProjectGame
{
    class Guardian : Enemy 
    {

        public Guardian()
        {
	          this.sprite= "     .----.                     " +
                        @"   _/\ ____\      _______       " +
                        @"  (/  /    .     /       \      " +
                         "  /  /    /     [  ()  ]  |     " +
                         " /  /  (\/    .-|_______-.---.  " +
                        @" | /    \\_  /  /       / / '\\ " +
                        @" \/____/|'.) \ (        \ ' ,'/ " +
                        @"        \ \\.' -\   '    '---'  " +
                        @"         \ \\  / )'|'   /   |   " +
                        @"          \ \\'  |_ _  |   /    " +
                        @"           \/\\ [_____. ' /     " +
                        @"              \\/   .'  .'\     " +
                        @"               \.-'_.'    |     " +
                        @"               (_.' ,      \    " +
                        @"               |  \\/\     |    " +
                        ;
            this.name = "Guardian";
            this.HP = 100;
            this.MAXHP = 100;
            this.STR = 9;
            this.DEF = 9;
            this.INT = 7;

        }

    }
}
