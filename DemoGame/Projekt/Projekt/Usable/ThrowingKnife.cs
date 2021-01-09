
using Projekt.Usable;
using System;

namespace Projekt
{
    class ThrowingKnife : IUsable
    {
        protected string Name;
        public ThrowingKnife() {
            Name = "Throwing Knife";
        }

        public string GetName() { return Name; }

        public void Use(Fight fight)
        {
            Player player = fight.GetPlayer();
            Enemy target = player.SelectTarget(fight);
            target.Hurt(player.getStat(4));
        }
    }
}
