
using Projekt.Usable;

namespace Projekt
{
    class WaterSpear : IUsable
    {
        private string Name;
        private int ManaCost = 15;
        public WaterSpear()
        {
            Name = "Water Pillar [15 MP]";
        }
        public string GetName() { return Name; }

        public void Use(Fight fight)
        {
            Player player = fight.GetPlayer();
            Enemy target = player.SelectTarget(fight);
            if (player.DrainMana(ManaCost))
                target.Hurt(35,true);
        }
    }
}
