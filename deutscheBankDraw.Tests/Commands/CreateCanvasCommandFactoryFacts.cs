using System.Threading;
using Xunit;
using Moq;
using DeutscheBankDraw.Commands;

namespace DeutscheBankDraw.Tests.Commands
{
    public class CreateCanvasCommandFactoryFacts
    {
        public class TheCreateMethod
        {
            [Fact]
            public void ShouldCreateAValidCanvasCommand()
            {
                var cmdFactory = new CreateCanvasCommandFactory();

                var cmd = cmdFactory.Create("C 20 5");

                Assert.IsType<CreateCanvasCommand>(cmd);
                var createCanvasCmd = cmd as CreateCanvasCommand;

                Assert.Equal(20, createCanvasCmd.Width);
                Assert.Equal(5, createCanvasCmd.Height);

            }
        }
    }
}

