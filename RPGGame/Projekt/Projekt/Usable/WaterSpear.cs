
using Projekt.Usable;

namespace Projekt
{
    class WaterSpear : IUsable
    {
        private string Name;
        private int ManaCost = 15;
        public WaterSpear()
        {
            Name = "Water Spear [15 MP]";
        }
        public string GetName() { return Name; }

        public void Use(Fight fight)
        {
            Player player = fight.GetPlayer();
            if (player.CheckIfEnoughMP(ManaCost))
            {
                Enemy target = player.SelectTarget(fight);
                target.Hurt(player.GetStat(6) * 3, true, player);
                player.DrainMana(ManaCost);
            }
        }
    }
}