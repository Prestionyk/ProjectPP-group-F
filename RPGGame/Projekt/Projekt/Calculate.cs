using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Calculate
    {
        public static int HitDamage(IStats attacker, IStats target)
        {
            return HitDamage(attacker, target, 100, false);
        }

        public static int HitDamage(IStats attacker, IStats target, int Power, bool Magical)
        {            
            float DMG = 0;
            int DEF = 0;
            bool Dodge = false;
            Random rand = new Random();

            if (!Magical)
            {
                DMG = attacker.GetStat("STR");
                DEF = target.GetStat("DEF");

                     

                if (rand.Next(100) + 1 <= target.GetStat("AGI")) //Unik
                {
                    Dodge = true;
                }
                else if (attacker is Player && rand.Next(100) + 1 <= attacker.GetStat("AGI")) //Krytk
                {
                    Log.Send("* Critical Hit!");
                    DMG *= 1.5f;
                }
            }
            else
                DMG = attacker.GetStat("INT");

            if (!Dodge)
                return (int)Math.Max(1, (DMG * (Power / 100) * (0.8f + rand.NextDouble() % 0.4f) - DEF / 2));
            else
                return 0;
        }
    }
}
