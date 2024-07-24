using Algorithms;

namespace AlgorithmsTests
{
    public class FibonacciTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(3, 2)]
        public void IfNumberInTheValidRange_ShallRetrunSumOfTheTwoPreviouseNumbers(int input, int result)
        {
            var fib = Fibonacci.RecursiveFib(input);
            Assert.That(fib, Is.EqualTo(result), $"Input: {input}");
        }

        [Test]
        [TestCase(47)]
        [TestCase(100)]
        public void IfInputLargerThan46_ShallThrowArgumentOutOfRangeException(int input)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Fibonacci.RecursiveFib(input), $"Input: {input}");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-12)]
        public void IfInputLessThanZero_ShallThrowArgumentOutOfRangeException(int input)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Fibonacci.RecursiveFib(input), $"Input: {input}");
        }
    }
}