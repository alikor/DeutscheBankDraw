using System;

namespace DeutscheBankDraw.Commands
{
    public class CreateCanvasCommand : ICommand
    {
        public CreateCanvasCommand(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public ICanvas Execute(ICanvas canvas)
        {
            return new Canvas(this.Width, this.Height);
        }
    }

    public class CreateCanvasCommandFactory : ICommandFactory
    {

        public CreateCanvasCommandFactory()
        {
        }
        public string CommandToken => "C";

        public ICommand Create(string line)
        {
            var tokens = line.Split(" ");
            return new CreateCanvasCommand(int.Parse(tokens[1]), int.Parse(tokens[2]));
        }
    }
}
