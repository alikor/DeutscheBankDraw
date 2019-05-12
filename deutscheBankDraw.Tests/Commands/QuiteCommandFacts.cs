using System;
using System.Threading;
using System.IO;
using Xunit;
using Moq;

using DeutscheBankDraw;
using DeutscheBankDraw.Commands;
using System.Collections.Generic;

namespace DeutscheBankDraw.Tests.Commands
{
    public class QuiteCommandFacts
    {
        public class TheExecuteMethod
        {
            [Fact]
            public void ShouldBeCanceled()
            {
                var tokenSource = new CancellationTokenSource();
                var mockCanvas = new Mock<ICanvas>();
                var cmd = new QuiteCommand(tokenSource);

                cmd.Execute(mockCanvas.Object);

                Assert.True(tokenSource.Token.IsCancellationRequested);

            }

            [Fact]
            public void ShouldNotBeCanceled()
            {
                var tokenSource = new CancellationTokenSource();
                var mockCanvas = new Mock<ICanvas>();
                var cmd = new QuiteCommand(tokenSource);

                Assert.False(tokenSource.Token.IsCancellationRequested);

            }
        }
    }
}

