namespace ProjectGame
{
    class Slime : Enemy 
    {

        public Slime()
        {
            this.sprite= "        _______        " +
                         "    _.-'       '-._    " +
                         "  -'   ()     ()   '-  " +
                        @" /      _______      \ " +
                        @" \___________________/ " ;

            this.name = "Slime";
            this.HP = 20;
            this.MAXHP = 20;
            this.STR = 3;
            this.DEF = 2;
            this.INT = 4;

        }

    }
}
