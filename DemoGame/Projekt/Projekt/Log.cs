using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Log
    {
        private static List<string> messages = new List<string>();
        //Wyświetla wszystko co się wydażyło w ostatniej turze
        public static void Send(string Message)
        {
            messages.Add(Message);
            if (messages.Count > 20)
                messages.RemoveAt(0);

            Update();
        }

        private static void Update()
        {
            Clear();
            for(int i = 0; i < messages.Count; i++)
            {
                Console.SetCursorPosition(69, 22 - messages.Count + i);
                Console.Write(messages[i]);
            }            
        }

        private static void Clear()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(69, 2 + i);
                Console.Write(new string(' ', 40));
            }
        }
    }
}
