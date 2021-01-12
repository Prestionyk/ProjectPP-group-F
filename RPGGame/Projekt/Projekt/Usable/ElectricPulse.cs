using Projekt.Usable;

namespace Projekt
{
    class ElectricPulse : IUsable
    {
        private readonly string Name;
        private readonly int ManaCost = 10;
        public ElectricPulse()
        {
            Name = "Elec Pulse [10 MP]";
        }
        public string GetName() { return Name; }

        public void Use(Fight fight)
        {
            Player player = fight.GetPlayer();
            if (player.CheckIfEnoughMP(ManaCost))
            {
                Enemy target = player.SelectTarget(fight);
                target.Hurt(Calculate.HitDamage(player, target, 250, true));
                player.DrainMana(ManaCost);
            }
        }
    }
}