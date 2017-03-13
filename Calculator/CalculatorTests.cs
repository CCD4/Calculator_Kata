using NUnit.Framework;

namespace Calculator
{
    [TestFixture]
    public class CalculatorTests
    {
        [TestCase(0.0, 1.0, 1.0)]
        [TestCase(12.0,3.0,123.0)]
        [TestCase(0.0,0.0,0.0)]
        public void Anhängen(double operand, double ziffer, double expected)
        {
            var calculator = new Calculator();
            calculator.Operand = operand;
            calculator.Anhängen(ziffer);
            Assert.AreEqual(expected, calculator.Operand);
        }

        [Test]
        public void AnhängenSequenziell()
        {
            var calculator = new Calculator();
            calculator.Operand = 0.0;
            calculator.Anhängen(0.0);
            calculator.Anhängen(0.0);
            Assert.AreEqual(0.0, calculator.Operand);
        }
    }
}
