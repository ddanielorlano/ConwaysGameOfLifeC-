using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace ConwaysGameOfLife.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGame()
        {

            var grid = new bool[5, 5];
            grid[0, 0] = true;
            grid[1, 0] = true;
            grid[2, 0] = true;

            var game = new Game();
            var result = game.Update(grid,5,5);
            result[1, 1].Should().BeTrue();
            result[0, 0].Should().BeFalse();
            result[2, 0].Should().BeFalse();
        }
    }
}
