using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Xunit;

namespace TestSimulator
{
    public class RectangleTests
    {
        [Fact]
        //Test sprawdzający, czy konstruktor ustawia właściwości
        public void Constructor_ValidCoordinates_ShouldSetValues()
        {
            var rect = new Rectangle(1, 2, 3, 4);
            Assert.Equal("(1, 2):(3, 4)", rect.ToString());
        }

        [Fact]
        //Test sprawdzający ArgumentException, kiedy punkty są współliniowe
        public void Constructor_InvalidRectangle_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Rectangle(2, 3, 2, 6));
            Assert.Throws<ArgumentException>(() => new Rectangle(3, 3, 5, 3));
        }

        [Fact]
        //Test sprawdzający, czy prostokąt zawiera dany punkt - true
        public void Contains_PointsInsideRectangle_ShouldReturnTrue()
        {
            var rect = new Rectangle(1, 1, 3, 3);
            Assert.True(rect.Contains(new Point(2, 2)));
            Assert.True(rect.Contains(new Point(1, 1)));
            Assert.True(rect.Contains(new Point(3, 3)));
        }

        [Fact]
        //Test sprawdzający, czy prostokąt zawiera dany punkt - false
        public void Contains_PointsOutsideRectangle_ShouldReturnFalse()
        {
            var rect = new Rectangle(1, 1, 3, 3);
            Assert.False(rect.Contains(new Point(0, 0)));
            Assert.False(rect.Contains(new Point(4, 4)));
            Assert.False(rect.Contains(new Point(2, 4)));
        }


    }
}
