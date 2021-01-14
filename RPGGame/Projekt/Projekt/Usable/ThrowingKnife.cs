using Projekt.Usable;

namespace Projekt
{
    class ThrowingKnife : IUsable
    {
        private readonly string Name;
        public ThrowingKnife() {
            Name = "Throwing Knife";
        }

        public string GetName() { return Name; }

        public void Use(Fight fight)
        {
            Player player = fight.GetPlayer();
            Enemy target = player.SelectTarget(fight);
            target.Hurt(Calculate.HitDamage(player, target, 200, false));
        }
    }
}
