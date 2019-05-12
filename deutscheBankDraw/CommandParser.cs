using System.Collections.Generic;
using System.Linq;
using DeutscheBankDraw.Commands;

namespace DeutscheBankDraw
{
    public interface ICommandParser
    {
        ICommand Parse(string line);
    }

    public class CommandParser : ICommandParser
    {
        private readonly IConsole console;
        private readonly IEnumerable<ICommandFactory> commandFactories;

        public CommandParser(IConsole console, IEnumerable<ICommandFactory> commandFactories)
        {
            this.console = console;
            this.commandFactories = commandFactories;
        }

        public ICommand Parse(string line)
        {
            var tmpline = line.ToUpper();
            var currenctCommandFactory = this.commandFactories.FirstOrDefault(c => tmpline.StartsWith(c.CommandToken));
            if (currenctCommandFactory == null)
            {
                return new UnknownCommand(this.console, line);
            }

            var cmd = currenctCommandFactory.Create(line);

            return cmd;
        }
    }
}
