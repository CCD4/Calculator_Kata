using System;
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
            var calculator = new Calculator(new Calculator.State {Operand = operand});
            calculator.Anhängen(ziffer);
            Assert.AreEqual(expected, calculator.Operand);
        }

        [Test]
        public void AnhängenSequenziell()
        {
            var calculator = new Calculator(new Calculator.State { Operand = 0});
            calculator.Anhängen(0.0);
            calculator.Anhängen(0.0);
            Assert.AreEqual(0.0, calculator.Operand);
        }

        [TestCase(12d, Operator.Minus, 19d, 7d, true)]
        [TestCase(12d, Operator.Plus, 19d, 31d, true)]
        [TestCase(12d, Operator.Mal, 19d, 228d, true)]
        [TestCase(4d, Operator.Durch, 12d, 3d, true)]
        [TestCase(0d, Operator.Durch, 12d, 12d, false)]
        [TestCase(0d, Operator.Durch, 0d, 0, false)]
        public void Rechnen(double operand, Operator @operator, double zwischenergebnisAlt, double zwischenergebnisNeu, bool result)
        {
            var calculator = new Calculator(new Calculator.State(operand, @operator, zwischenergebnisAlt));
            var success = calculator.Rechnen();

            Assert.AreEqual(result, success);
            Assert.AreEqual(zwischenergebnisNeu, calculator.Zwischenergebnis);
            Assert.AreEqual(operand, calculator.Operand);
        }
    }
}
