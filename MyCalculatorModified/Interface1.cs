using System;
using System.Collections.Generic;
using System.Text;

namespace MyCalculatorModified
{
    public interface ILogger
    {
        void Event(string Message);

        void Error(string Message);
    }

    public class Logger: ILogger
    {
        public void Event(string Message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine(Message);

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Error(string Message)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(Message);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
