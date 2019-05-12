using System.Threading;

namespace DeutscheBankDraw.Commands
{
    public class QuiteCommand : ICommand
    {

        private readonly CancellationTokenSource cancellationTokenSource;

        public QuiteCommand(CancellationTokenSource cancellationTokenSource)
        {
            this.cancellationTokenSource = cancellationTokenSource;
        }

        public ICanvas Execute(ICanvas canvas)
        {
            this.cancellationTokenSource.Cancel();
            return canvas;
        }

    }

    public class QuiteCommandFactory : ICommandFactory
    {
        private readonly CancellationTokenSource cancellationTokenSource;

        public QuiteCommandFactory(CancellationTokenSource cancellationTokenSource)
        {
            this.cancellationTokenSource = cancellationTokenSource;
        }
        public string CommandToken => "Q";

        public ICommand Create(string line)
        {
            return new QuiteCommand(this.cancellationTokenSource);
        }
    }
}
