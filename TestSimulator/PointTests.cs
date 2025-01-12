using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace TestSimulator
{
    public class PointTests
    {
        [Fact]
        //Test sprawdzający, czy metoda Next() zwraca poprawny punkt
        public void Next_ShouldReturnCorrectPoint()
        {
            var point = new Point(5, 5);
            var next = point.Next(Direction.Up);
            Assert.Equal(new Point(5, 6), next);
            var next2 = point.Next(Direction.Down);
            Assert.Equal(new Point(5, 4), next2);
            var next3 = point.Next(Direction.Right);
            Assert.Equal(new Point(6, 5), next3);
            var next4 = point.Next(Direction.Left);
            Assert.Equal(new Point(4, 5), next4);
        }

        [Fact]
        //Test sprawdzający, czy metoda NextDiagonal() zwraca poprawny punkt
        public void NextDiagonal_ShouldReturnCorrectPoint()
        {
            var point = new Point(5, 5);
            var next = point.NextDiagonal(Direction.Up);
            Assert.Equal(new Point(6, 6), next);
            var next2 = point.NextDiagonal(Direction.Down);
            Assert.Equal(new Point(4, 4), next2);
            var next3 = point.NextDiagonal(Direction.Right);
            Assert.Equal(new Point(6, 4), next3);
            var next4 = point.NextDiagonal(Direction.Left);
            Assert.Equal(new Point(4, 6), next4);
        }
    }
}
