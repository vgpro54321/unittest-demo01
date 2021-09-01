using Excercise.Services;
using Xunit;

namespace Excersise.Tests
{
    public class AccumulatorTests
    {
        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(0.1, 0.2, 0.3)]
        [InlineData(1, 1, 2)]
        [InlineData(3.1, 7, 10.1)]
        [InlineData(4.2, 0.1, 4.3)]
        [InlineData(6.3, 0.1, 6.4)]
        public void Add_ShouldReturnSumOfValues(double input, double change, double expectedResult)
        {
            //Arrange
            IAccumulator accumulator = new Accumulator();

            //Act
            var result = accumulator.Add(input, change);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
