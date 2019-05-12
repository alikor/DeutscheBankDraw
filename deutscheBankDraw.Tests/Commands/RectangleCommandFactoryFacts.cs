using Xunit;
using DeutscheBankDraw.Commands;

namespace DeutscheBankDraw.Tests.Commands
{
    public class RectangleCommandFactoryFacts
    {
        public class TheCreateMethod
        {
            [Fact]
            public void ShouldCreateAValidRectangleCommand()
            {
                var cmdFactory = new RectangleCommandFactory();

                var cmd = cmdFactory.Create("L 1 2 3 4");

                Assert.IsType<RectangleCommand>(cmd);
                var createCanvasCmd = cmd as RectangleCommand;

                Assert.Equal(1 - 1, createCanvasCmd.Start.X);
                Assert.Equal(2 - 1, createCanvasCmd.Start.Y);
                Assert.Equal(3 - 1, createCanvasCmd.End.X);
                Assert.Equal(4 - 1, createCanvasCmd.End.Y);

            }
        }
    }
}

