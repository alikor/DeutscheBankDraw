namespace DeutscheBankDraw.Commands
{
    public class LineCommand : ICommand
    {
        public LineCommand(System.Drawing.Point start, System.Drawing.Point end)
        {
            Start = start;
            End = end;
        }
        public System.Drawing.Point Start { get; private set; }
        public System.Drawing.Point End { get; private set; }

        public ICanvas Execute(ICanvas canvas)
        {
            if (isVerticalLine())
            {
                return drawVerticalLine(canvas, this.Start.X, this.Start.Y, this.End.Y);
            }

            return drawHorizontalLine(canvas, this.Start.Y, this.Start.X, this.End.X);
        }

        bool isVerticalLine()
        {
            return this.Start.X == this.End.X;
        }

        ICanvas drawHorizontalLine(ICanvas canvas, int y, int startX, int endX)
        {
            if (startX > endX)
            {
                Swap(ref startX, ref endX);
            }

            for (int i = startX; i <= endX; i++)
            {
                canvas.SetElement(i, y, 'x');
            }

            return canvas;
        }

        ICanvas drawVerticalLine(ICanvas canvas, int x, int startY, int endY)
        {
            if (startY > endY)
            {
                Swap(ref startY, ref endY);
            }

            for (int i = startY; i <= endY; i++)
            {
                canvas.SetElement(x, i, 'x');
            }

            return canvas;

        }

        static void Swap(ref int v1, ref int v2)
        {
            v1 = v1 + v2;
            v2 = v1 - v2;
            v1 = v1 - v2;
        }
    }

    public class LineCommandFactory : ICommandFactory
    {

        public LineCommandFactory()
        {
        }
        public string CommandToken => "L";

        public ICommand Create(string line)
        {
            var tokens = line.Split(" ");
            var start = new System.Drawing.Point(int.Parse(tokens[1]) - 1, int.Parse(tokens[2]) - 1);
            var end = new System.Drawing.Point(int.Parse(tokens[3]) - 1, int.Parse(tokens[4]) - 1);

            return new LineCommand(start, end);
        }
    }

}
