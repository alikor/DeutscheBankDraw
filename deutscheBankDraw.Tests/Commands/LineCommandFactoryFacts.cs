using Xunit;
using DeutscheBankDraw.Commands;

namespace DeutscheBankDraw.Tests.Commands
{
    public class LineCommandFactoryFacts
    {
        public class TheCreateMethod
        {
            [Fact]
            public void ShouldCreateAValidLineCommand()
            {
                var cmdFactory = new LineCommandFactory();

                var cmd = cmdFactory.Create("L 1 2 3 4");

                Assert.IsType<LineCommand>(cmd);
                var createCanvasCmd = cmd as LineCommand;

                Assert.Equal(1 - 1, createCanvasCmd.Start.X);
                Assert.Equal(2 - 1, createCanvasCmd.Start.Y);
                Assert.Equal(3 - 1, createCanvasCmd.End.X);
                Assert.Equal(4 - 1, createCanvasCmd.End.Y);

            }
        }
    }
}

