
using Projekt.Usable;
using System.Threading;

namespace Projekt
{
    class Heal : IUsable
    {
        private string Name;
        private int ManaCost = 10;
        public Heal()
        {
            Name = "Heal [10 MP]";
        }
        public string GetName() { return Name; }

        public void Use(Fight fight)
        {
            Player player = fight.GetPlayer();
            if (player.CheckIfEnoughMP(ManaCost))
            {
                player.Heal(25);
                player.DrainMana(ManaCost);
            }
        }
    }
}