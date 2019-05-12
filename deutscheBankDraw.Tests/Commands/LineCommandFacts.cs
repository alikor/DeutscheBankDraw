using Xunit;
using System.Linq;
using DeutscheBankDraw.Commands;

namespace DeutscheBankDraw.Tests.Commands
{
    public class LineCommandFacts
    {
        public class TheExecuteMethod
        {

            [Fact]
            public void ShouldDrawHorizontalLineLeftToRight()
            {
                var start = new System.Drawing.Point(0, 2);
                var end = new System.Drawing.Point(6, 2);
                var cmd = new LineCommand(start, end);

                var canvas = new Canvas(20, 5);

                var result = cmd.Execute(canvas);

                var expected = new char[20, 5];

                expected[0, 2] = 'x';
                expected[1, 2] = 'x';
                expected[2, 2] = 'x';
                expected[3, 2] = 'x';
                expected[4, 2] = 'x';
                expected[5, 2] = 'x';
                expected[6, 2] = 'x';

                Assert.Equal(expected, result.Data);

            }

            [Fact]
            public void ShouldDrawHorizontalLineRightToLeft()
            {
                var start = new System.Drawing.Point(6, 2);
                var end = new System.Drawing.Point(0, 2);
                var cmd = new LineCommand(start, end);

                var canvas = new Canvas(20, 5);

                var result = cmd.Execute(canvas);

                var expected = new char[20, 5];

                expected[0, 2] = 'x';
                expected[1, 2] = 'x';
                expected[2, 2] = 'x';
                expected[3, 2] = 'x';
                expected[4, 2] = 'x';
                expected[5, 2] = 'x';
                expected[6, 2] = 'x';

                Assert.Equal(expected, result.Data);

            }

            [Fact]
            public void ShouldDrawVerticalLineLeftToRight()
            {
                var start = new System.Drawing.Point(6, 0);
                var end = new System.Drawing.Point(6, 2);
                var cmd = new LineCommand(start, end);

                var canvas = new Canvas(20, 5);

                var result = cmd.Execute(canvas);

                var expected = new char[20, 5];

                expected[6, 0] = 'x';
                expected[6, 1] = 'x';
                expected[6, 2] = 'x';

                Assert.Equal(expected, result.Data);

            }

            [Fact]
            public void ShouldDrawVerticalLineRightToLeft()
            {
                var start = new System.Drawing.Point(6, 2);
                var end = new System.Drawing.Point(6, 0);
                var cmd = new LineCommand(start, end);

                var canvas = new Canvas(20, 5);

                var result = cmd.Execute(canvas);

                var expected = new char[20, 5];

                expected[6, 0] = 'x';
                expected[6, 1] = 'x';
                expected[6, 2] = 'x';

                Assert.Equal(expected, result.Data);

            }
        }
    }
}

