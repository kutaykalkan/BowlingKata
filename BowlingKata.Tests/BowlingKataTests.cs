using System;
using Xunit;

namespace BowlingKata
{
    public class BowlingKataTests : IDisposable
    {
        private Game g;
        public BowlingKataTests()
        {
            g = new Game();
        }
        
        [Fact]
        public void TestGutterGame()
        {
            RollMany(20, 0);
            Assert.Equal(0, g.TotalScore);
        }

        [Fact]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.Equal(20, g.TotalScore);
        }

        [Fact]
        public void TestOneSpare()
        {
            rollSpare();
            g.Roll(3);
            RollMany(17, 0);
            Assert.Equal(16, g.TotalScore);
        }

        [Fact]
        public void TestPerfectGame()
        {
            RollMany(12, 10);
            Assert.Equal(300, g.TotalScore);
        }

        [Fact]
        public void TestOneStrike()
        {
            rollStrike();
            g.Roll(3);
            g.Roll(4);
            RollMany(16, 0);
            Assert.Equal(24, g.TotalScore);
        }

        private void rollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }

        private void rollStrike()
        {
            g.Roll(10);
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                g.Roll(pins);
            }
        }

        public void Dispose()
        {
            g = null;
        }
    }
}