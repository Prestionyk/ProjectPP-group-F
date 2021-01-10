
using Projekt.Usable;
using System.Threading;

namespace Projekt
{
    class Heal : IUsable
    {
        private string Name;
        private int ManaCost = 6;
        public Heal()
        {
            Name = "Heal [6 MP]";
        }
        public string GetName() { return Name; }

        public void Use(Fight fight)
        {
            Player player = fight.GetPlayer();
            if (player.CheckIfEnoughMP(ManaCost))
            {
                player.Heal(30);
                player.DrainMana(ManaCost);
            }
        }
    }
}