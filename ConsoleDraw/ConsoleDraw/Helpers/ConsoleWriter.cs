using System;
using ConsoleDraw.Interfaces;

namespace ConsoleDraw.Helpers
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void Write(string message) => Console.WriteLine($"{message}");

        public void Write(char c) => Console.Write(c);

        public void WriteLine() => Console.WriteLine();
    }
}
