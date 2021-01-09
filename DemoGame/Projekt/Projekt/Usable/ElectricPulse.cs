using Projekt.Usable;

namespace Projekt
{
    class ElectricPulse : IUsable
    {
        private string Name;
        private int ManaCost = 10;
        public ElectricPulse()
        {
            Name = "Electric Pulse [10 MP]";
        }
        public string GetName() { return Name; }

        public void Use(Fight fight)
        {
            Player player = fight.GetPlayer();
            Enemy target = player.SelectTarget(fight);
            if (player.DrainMana(ManaCost))
                target.Hurt(25,true);
        }
    }
}
