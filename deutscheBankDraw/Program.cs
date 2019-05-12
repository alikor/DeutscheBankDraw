using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using DeutscheBankDraw.Commands;

namespace DeutscheBankDraw
{
    class Program
    {

        static void Main(string[] args)
        {
            var cmds = new List<ICommandFactory>();

            cmds.Add(new CreateCanvasCommandFactory());
            cmds.Add(new LineCommandFactory());
            cmds.Add(new RectangleCommandFactory());

            using (var tokenSource = new CancellationTokenSource())
            {
                var cancelToken = CreateQuiteCommandFactory(cmds, tokenSource);
                var parser = new CommandParser(new ConsoleWrapper(), cmds);
                Task.Factory.StartNew(() => run(parser, cancelToken), cancelToken).Wait();
            }
        }

        private static void run(ICommandParser parser, CancellationToken cancelToken)
        {
            var drawer = new Drawer();
            while (cancelToken.IsCancellationRequested == false)
            {
                Console.Write("enter command: ");
                var line = Console.ReadLine();
                var cmd = parser.Parse(line);

                drawer.Paint(cmd);

                if (cancelToken.IsCancellationRequested == false)
                {
                    Print(drawer.Canvas);
                }
            }
        }

        private static void Print(ICanvas canvas)
        {
            printBorderTopAndBottom(canvas);

            for (int i = 0; i < canvas.Height; i++)
            {
                Console.Write("|");
                for (int j = 0; j < canvas.Width; j++)
                {

                    var cell = canvas.Data[j, i];
                    if (cell != '\0')
                    {
                        Console.Write(string.Format("{0}", cell));
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("|");
                Console.Write(Environment.NewLine);
            }
            printBorderTopAndBottom(canvas);
        }

        static void printBorderTopAndBottom(ICanvas canvas)
        {
            for (int i = 0; i < canvas.Width + 2; i++)
            {
                Console.Write("-");
            }
            Console.Write(Environment.NewLine);
        }

        private static CancellationToken CreateQuiteCommandFactory(List<ICommandFactory> cmds, CancellationTokenSource tokenSource)
        {
            cmds.Add(new QuiteCommandFactory(tokenSource));
            return tokenSource.Token;
        }

    }
}
