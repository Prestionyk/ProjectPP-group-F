using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            
            Player player = new Player();
            while (true)
                player.SelectAction();
                        
        }
    }
}
