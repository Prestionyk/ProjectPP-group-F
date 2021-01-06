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
            return Console.ReadKey(true).Key;
        }
    }
}
