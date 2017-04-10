using System;
using NUnit.Framework;

namespace Calculator
{
    [TestFixture]
    public class CalculatorTests
    {
        [TestCase(0.0, 1, 1.0)]
        [TestCase(12.0,3,123.0)]
        [TestCase(0.0,0,0.0)]
        public void Anhängen(double operand, int ziffer, double expected)
        {
            var calculator = new Calculator(new Calculator.State {Operand = operand});
            calculator.Anhängen(ziffer);
            Assert.AreEqual(expected, calculator.Operand);
        }

        [Test]
        public void AnhängenSequenziell()
        {
            var calculator = new Calculator(new Calculator.State { Operand = 0});
            calculator.Anhängen(0);
            calculator.Anhängen(0);
            Assert.AreEqual(0.0, calculator.Operand);
        }

    }
}
