using NUnit.Framework;

namespace Calculator
{
    [TestFixture]
    public class RechwerkTest
    {

        [TestCase(12d, Operator.Minus, 19d, 7d, true)]
        [TestCase(12d, Operator.Plus, 19d, 31d, true)]
        [TestCase(12d, Operator.Mal, 19d, 228d, true)]
        [TestCase(4d, Operator.Durch, 12d, 3d, true)]
        [TestCase(0d, Operator.Durch, 12d, 0d, false)]
        [TestCase(0d, Operator.Durch, 0d, 0, false)]
        public void Rechnen(double operand, Operator @operator, double zwischenergebnisAlt, double zwischenergebnisNeu, bool result)
        {

            bool success = true;
            double actualErgebnis = 0;
            Rechenwerk.Rechnen(zwischenergebnisAlt, @operator, operand, (ergebnis) => actualErgebnis = ergebnis, () => success = false);

            Assert.AreEqual(result, success);
            Assert.AreEqual(zwischenergebnisNeu, actualErgebnis);
        }
    }
}