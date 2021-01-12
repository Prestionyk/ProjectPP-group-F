using Projekt.Usable;

namespace Projekt
{
    class Fireball : IUsable
    {
        private readonly string Name;
        private readonly int ManaCost = 4;
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
                target.Hurt(Calculate.HitDamage(player, target, 100, true));
                player.DrainMana(ManaCost);
            }
        }
    }
}