using Xunit;
using Moq;
using DeutscheBankDraw.Commands;
using System.Collections.Generic;

namespace DeutscheBankDraw.Tests
{
    public class DrawerFacts
    {
        public class ThePaintMethod
        {
            [Fact]
            public void ShouldExecuteCommand()
            {
                var mockCmd = new Mock<ICommand>();

                var drawer = new Drawer();
                drawer.Paint(mockCmd.Object);

                mockCmd.Verify(cmd => cmd.Execute(It.IsAny<ICanvas>()), Times.Once());
            }
        }
    }

}

