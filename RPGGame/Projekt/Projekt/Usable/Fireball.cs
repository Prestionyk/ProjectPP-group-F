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
            if (player.CheckIfEnoughMP(ManaCost))
            {
                Enemy target = player.SelectTarget(fight);
                target.Hurt(player.GetStat(6), true, player);
                player.DrainMana(ManaCost);
            }
        }
    }
}