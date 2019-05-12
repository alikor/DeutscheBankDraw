using System;
using System.Threading;
using System.IO;
using Xunit;
using Moq;

using DeutscheBankDraw;
using DeutscheBankDraw.Commands;
using System.Collections.Generic;


namespace DeutscheBankDraw.Tests
{
    public class CommandParserFacts
    {
        public class TheParseMethod
        {
            [Fact]
            public void ShouldFindValidCommand()
            {
                var commands = new List<ICommandFactory>();
                var mockConsole = new Mock<IConsole>();

                var mockCmdFactory = new Mock<ICommandFactory>();
                var mockCmd = new Mock<ICommand>();
                mockCmdFactory.Setup(c => c.CommandToken).Returns("ValidCommand".ToUpper());
                mockCmdFactory.Setup(cf => cf.Create(It.IsAny<string>())).Returns(mockCmd.Object);

                commands.Add(mockCmdFactory.Object);
                var commandParser = new CommandParser(mockConsole.Object, commands);

                var resultCmd = commandParser.Parse("ValidCommand 1 3");

                Assert.Equal(mockCmd.Object, resultCmd);
            }

            [Fact]
            public void CannotFindCommand()
            {
                var commands = new List<ICommandFactory>();
                var mockConsole = new Mock<IConsole>();

                var mockCmdFactory = new Mock<ICommandFactory>();
                var commandParser = new CommandParser(mockConsole.Object, commands);

                var resultCmd = commandParser.Parse("InvalidCommand 1 3");

                Assert.IsType<UnknownCommand>(resultCmd);
            }
        }
    }

}

