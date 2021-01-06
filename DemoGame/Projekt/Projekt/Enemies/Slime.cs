namespace Projekt
{
    class Slime : Enemy 
    {

        public Slime()
        {
                 sprite= "        _______        " +
                         "    _.-'       '-._    " +
                         "  -'   ()     ()   '-  " +
                        @" /      _______      \ " +
                        @" \___________________/ " ;

            name = "Slime";
            HP = 20;
            MAXHP = 20;
            STR = 3;
            DEF = 2;
            INT = 4;

        }

    }
}
