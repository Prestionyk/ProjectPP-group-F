
using Projekt.Usable;
using System;

namespace Projekt
{
    class HealthPotion : IUsable
    {
        protected string Name;
        public HealthPotion() {
            Name = "Health Potion";
        }

        public string GetName() { return Name; }

        public void Use(Fight fight)
        {
            fight.GetPlayer().Heal(20);
        }
    }
}
