using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Xunit;

namespace TestSimulator
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData(5,0,10,5)]
        [InlineData(-1, 0, 10, 0)]
        [InlineData(11, 0, 10, 10)]
        //Test sprawdzający, czy metoda Limiter zwraca poprawną wartość
        public void Limiter_ShouldClampValueCorrectly(int value, int min, int max, int expected)
        {
            Assert.Equal(expected, Validator.Limiter(value, min, max));
        }

        [Theory]
        [InlineData("Test", 3, 5, '#', "Test")]
        [InlineData("Te", 3, 5, '#', "Te#")]
        [InlineData("Testing", 3, 5, '#', "Testi")]
        //Test sprawdzający, czy metoda Shortener skraca lub uzupełnia string poprawnie
        public void Shortener_ShouldShortenOrPadStringCorrectly(string value, int min, int max, char placeholder, string expected)
        {
            Assert.Equal(expected, Validator.Shortener(value, min, max, placeholder));
        }

        [Fact]
        //Test sprawdzający, czy metoda isAlreadyInitialized zwraca false, gdy właściwość jest już zainicjalizowana
        public void IsAlreadyInitialized_ShouldReturnFalseIfAlreadyInitialized()
        {
            Assert.False(Validator.isAlreadyInitialized(true, "Test"));
        }

        [Fact]
        //Test sprawdzający, czy metoda isAlreadyInitialized zwraca true, gdy właściwość nie jest zainicjalizowana
        public void IsAlreadyInitialized_ShouldReturnTrueIfNotInitialized()
        {
            Assert.True(Validator.isAlreadyInitialized(false, "Test"));
        }

    }
}
