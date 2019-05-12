using System.Collections.Generic;

namespace DeutscheBankDraw.Commands
{
    public interface ICommand
    {

        ICanvas Execute(ICanvas canvas);


    }

    public interface ICommandFactory
    {
        string CommandToken { get; }

        ICommand Create(string line);
    }
}
