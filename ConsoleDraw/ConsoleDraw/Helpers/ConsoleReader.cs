using System;
using ConsoleDraw.Interfaces;

namespace ConsoleDraw.Helpers
{
    public class ConsoleReader : IConsoleReader
    {
        public string Read(string message)
        {
            Console.Write($"{message}");
            return Console.ReadLine();
        }
    }
}
