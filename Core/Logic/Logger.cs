using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Logger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void Log(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{DateTime.Now.ToShortTimeString()} {message}");
            Console.ResetColor();
        }
    }
}
