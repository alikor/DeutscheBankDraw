using Xunit;
using DeutscheBankDraw.Commands;

namespace DeutscheBankDraw.Tests.Commands
{
    public class CreateCanvasCommandFacts
    {
        public class TheExecuteMethod
        {

            [Fact]
            public void ShouldCreateACanvasWithCorrectDimensionsAndSize()
            {
                var width = 4;
                var height = 20;
                var cmd = new CreateCanvasCommand(width, height);

                var canvas = new Canvas();

                var result = cmd.Execute(canvas);

                Assert.Equal(width, result.Width);
                Assert.Equal(height, result.Height);
            }
        }
    }
}

