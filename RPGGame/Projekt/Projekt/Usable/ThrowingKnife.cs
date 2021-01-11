using Projekt.Usable;

namespace Projekt
{
    class ThrowingKnife : IUsable
    {
        private string Name;
        public ThrowingKnife() {
            Name = "Throwing Knife";
        }

        public string GetName() { return Name; }

        public void Use(Fight fight)
        {
            Player player = fight.GetPlayer();
            Enemy target = player.SelectTarget(fight);
            target.Hurt((int)(player.GetStat("STR") * (1.5)),player);
        }
    }
}
