using System;

namespace DeutscheBankDraw.Commands
{
    public class UnknownCommand : ICommand
    {
        private readonly IConsole console;
        private readonly string line;

        public UnknownCommand(IConsole console, string line)
        {
            this.console = console;
            this.line = line;
        }

        public ICanvas Execute(ICanvas canvas)
        {
            this.console.WriteLine($"Unknown command: {this.line}");
            return canvas;
        }

        public string CommandToken { get; } = "";
    }
}
