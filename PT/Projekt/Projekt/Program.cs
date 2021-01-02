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

            Menu menu = new Menu();
            menu.DrawMenu();
            string Action = menu.SelectAction();

            typeof(Program).GetMethod(Action).Invoke(new Program(), null);
            Console.ReadKey();
        }

        public void Attack()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("test");
        }
    }
}
