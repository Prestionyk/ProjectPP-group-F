
using Projekt.Usable;

namespace Projekt
{
    class WaterSpear : IUsable
    {
        private readonly string Name;
        private readonly int ManaCost = 15;
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
                target.Hurt(Calculate.HitDamage(player, target, 400, true));
                player.DrainMana(ManaCost);
            }
        }
    }
}