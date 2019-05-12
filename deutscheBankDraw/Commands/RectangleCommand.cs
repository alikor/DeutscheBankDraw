namespace DeutscheBankDraw.Commands
{
    public class RectangleCommand : ICommand
    {
        public RectangleCommand(System.Drawing.Point start, System.Drawing.Point end)
        {
            Start = start;
            End = end;
        }
        public System.Drawing.Point Start { get; private set; }
        public System.Drawing.Point End { get; private set; }

        public ICanvas Execute(ICanvas canvas)
        {
            var width = this.End.X - this.Start.X;
            var height = this.End.Y - this.Start.Y;


            var line1 = new LineCommand(
                this.Start,
                new System.Drawing.Point(this.Start.X + width, this.Start.Y));

            canvas = line1.Execute(canvas);

            var line2 = new LineCommand(
                this.Start,
                new System.Drawing.Point(this.Start.X, this.Start.Y + height));

            canvas = line2.Execute(canvas);

            var line3 = new LineCommand(
                new System.Drawing.Point(this.Start.X, this.Start.Y + height),
                this.End);

            canvas = line3.Execute(canvas);


            var line4 = new LineCommand(
                new System.Drawing.Point(this.Start.X + width, this.Start.Y),
                this.End);

            canvas = line4.Execute(canvas);

            return canvas;
        }
    }

    public class RectangleCommandFactory : ICommandFactory
    {

        public string CommandToken => "R";

        public ICommand Create(string line)
        {
            var tokens = line.Split(" ");
            var start = new System.Drawing.Point(int.Parse(tokens[1]) - 1, int.Parse(tokens[2]) - 1);
            var end = new System.Drawing.Point(int.Parse(tokens[3]) - 1, int.Parse(tokens[4]) - 1);

            return new RectangleCommand(start, end);
        }
    }
}
