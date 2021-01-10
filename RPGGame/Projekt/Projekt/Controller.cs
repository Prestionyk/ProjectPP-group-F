using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Controller
    {
        public static ConsoleKey GetButton()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            while (Console.KeyAvailable)
                Console.ReadKey(true);
            return key;
        }
    }
}
