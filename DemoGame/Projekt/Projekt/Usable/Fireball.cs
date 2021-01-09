using Projekt.Usable;

namespace Projekt
{
    class Fireball : IUsable
    {
        private string Name;
        private int ManaCost = 4;
        public Fireball()
        {
            Name = "Fireball [4 MP]";
        }
        public string GetName() { return Name; }

        public void Use(Fight fight)
        {
            Player player = fight.GetPlayer();
            Enemy target = player.SelectTarget(fight);
            if(player.DrainMana(ManaCost))
                target.Hurt(15,true);
        }
    }
}
