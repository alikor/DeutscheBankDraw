using System.Threading;
using Xunit;
using Moq;
using DeutscheBankDraw.Commands;

namespace DeutscheBankDraw.Tests.Commands
{
    public class UnknownCommandFacts
    {
        public class TheExecuteMethod
        {
            [Fact]
            public void ShouldBeCanceled()
            {
                var commandLine = "SomeUnknownCommand";
                var mockConsole = new Mock<IConsole>();
                var mockCanvas = new Mock<ICanvas>();
                var cmd = new UnknownCommand(mockConsole.Object, commandLine);

                cmd.Execute(mockCanvas.Object);

                mockConsole.Verify(console => console.WriteLine($"Unknown command: {commandLine}"), Times.Once());

            }
        }
    }

}

