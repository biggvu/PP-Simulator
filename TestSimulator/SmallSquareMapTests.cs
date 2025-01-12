using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;
using Xunit;

namespace TestSimulator
{
    public class SmallSquareMapTests
    {
        [Fact]
        //Test sprawdzający, czy konstruktor ustawia właściwość Size
        public void Constructor_ValidSize_ShouldSetSize()
        {
            var map = new SmallSquareMap(10);
            Assert.Equal(10, map.SizeX);
            Assert.Equal(10, map.SizeY);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(21)]
        //Test sprawdzający, czy konstruktor rzuca wyjątek, gdy podany rozmiar jest z poza zakresu
        public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int size)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
        }

        [Fact]
        //Test sprawdzający, czy metoda Exist zwraca true dla punktu znajdującego się na mapie
        public void Exist_ValidPoint_ShouldReturnTrue()
        {
            var map = new SmallSquareMap(10);
            var point = new Point(5, 5);
            Assert.True(map.Exist(point));
        }

        [Fact]
        //Test sprawdzający, czy metoda Exist zwraca false dla punktu znajdującego się poza mapą
        public void Exist_PointOutsiedMapo_ShouldReturnFalse()
        {
            var map = new SmallSquareMap(10);
            var point = new Point(11, 5);
            Assert.False(map.Exist(point));
        }

        [Fact]
        //Test sprawdzający, czy metoda Next zwraca poprawny punkt
        public void Next_ShouldWrapAround()
        {
            var map = new SmallSquareMap(10);
            var point = new Point(0, 9);
            var next = map.Next(point, Direction.Up);
            Assert.Equal(new Point(0, 0), next);
        }

        [Fact]
        //Test sprawdzający, czy metoda NextDiagonal zwraca poprawny punkt
        public void NextDiagonal_ShouldWrapAround()
        {
            var map = new SmallSquareMap(10);
            var point = new Point(9, 9);
            var next = map.NextDiagonal(point, Direction.Right);
            Assert.Equal(new Point(0, 8), next);
        }

        [Theory]
        [InlineData(5, 10, Direction.Up, 6, 11)] 
        [InlineData(0, 0, Direction.Down, 19, 19)] 
        [InlineData(0, 8, Direction.Left, 19, 9)] 
        [InlineData(19, 10, Direction.Right, 0, 9)]

        //Test sprawdzający, czy metoda NextDiagonal zwraca poprawny punkt
        public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
        {
            var map = new SmallTorusMap(20);
            var point = new Point(x, y);

            var nextPoint = map.NextDiagonal(point, direction);

            Assert.Equal(new Point(expectedX, expectedY), nextPoint);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(20)]
        //Test sprawdzający, czy konstruktor ustawia właściwość Size dla granicznych rozmiarów
        public void Constructor_ExtremeSizes_ShouldSetSize(int size)
        {
            var map = new SmallSquareMap(size);
            Assert.Equal(size, map.SizeX);
        }

        [Fact]
        //Test sprawdzający zawijanie się przy minimalnym rozmiarze mapy
        public void NextDiagonal_MinimalSize_ShouldWrapAround()
        {
            var map = new SmallSquareMap(5);
            var point = new Point(4, 4);
            var next = map.NextDiagonal(point, Direction.Right);
            Assert.Equal(new Point(0, 3), next);
        }

        [Fact]
        //Test sprawdzający zawijanie się przy maksymalnym rozmiarze mapy
        public void NextDiagonal_MaximalSize_ShouldWrapAround()
        {
            var map = new SmallSquareMap(20);
            var point = new Point(19, 19);
            var next = map.NextDiagonal(point, Direction.Right);
            Assert.Equal(new Point(0, 18), next);
        }

        [Theory]
        [InlineData(5, 4, 4, Direction.Right, 0, 3)]
        [InlineData(20, 19, 19, Direction.Right, 0, 18)]
        //Test sprawdzający zawijanie się przy granicznych rozmiarach mapy
        public void NextDiagonal_ExtremeSizes_ShouldWrapAround(int size, int x, int y, Direction direction, int expectedX, int expectedY)
        {
            var map = new SmallSquareMap(size);
            var point = new Point(x, y);
            var next = map.NextDiagonal(point, direction);
            Assert.Equal(new Point(expectedX, expectedY), next);
        }
    }
}
