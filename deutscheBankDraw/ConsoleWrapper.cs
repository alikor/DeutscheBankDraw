using System;

namespace DeutscheBankDraw
{
    public class ConsoleWrapper : IConsole
    {
        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }
    }
}
