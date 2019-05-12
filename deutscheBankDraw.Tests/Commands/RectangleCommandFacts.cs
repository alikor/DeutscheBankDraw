using Xunit;
using DeutscheBankDraw.Commands;

namespace DeutscheBankDraw.Tests.Commands
{
    public class RectangleCommandFacts
    {
        public class TheExecuteMethod
        {

            [Fact]
            public void ShouldDrawRectangle()
            {
                var start = new System.Drawing.Point(0, 0);
                var end = new System.Drawing.Point(2, 2);
                var cmd = new RectangleCommand(start, end);

                var canvas = new Canvas(3, 3);

                var result = cmd.Execute(canvas);

                var expected = new char[3, 3] {
                    {'x', 'x', 'x'},
                    {'x', '\0','x'},
                    {'x', 'x' ,'x'}
                };

                Assert.Equal(expected, result.Data);

            }

        }
    }
}

