using Microsoft.Win32;
using NUnit.Framework;

namespace Calculator
{
    [TestFixture]
    class UseCaseTests
    {
        [Test]
        public void OperandErweitern()
        {
            var useCases = new UseCases();
            Assert.AreEqual(3, useCases.OperandErweitern('3'));
            Assert.AreEqual(34, useCases.OperandErweitern('4'));
            Assert.AreEqual(340, useCases.OperandErweitern('0'));
        }

        [Test]
        public void Rechnen()
        {
            var useCases = new UseCases();
            useCases.OperandErweitern('2');
            var zahl = useCases.OperandErweitern('0');
            Assert.AreEqual(20d, zahl);
            var result = useCases.Rechnen(Operator.Plus);
            Assert.IsTrue(result.Item1);
            Assert.AreEqual(20, result.Item2);
            zahl = useCases.OperandErweitern('3');
            Assert.AreEqual(3, zahl);
            result = useCases.Rechnen(Operator.Mal);
            Assert.IsTrue(result.Item1);
            Assert.AreEqual(23d, result.Item2);
            zahl = useCases.OperandErweitern('4');
            Assert.AreEqual(4, zahl);
            result = useCases.Rechnen();
            Assert.IsTrue(result.Item1);
            Assert.AreEqual(92d, result.Item2);
            result = useCases.Rechnen(Operator.Plus);
            Assert.IsTrue(result.Item1);
            Assert.AreEqual(92d, result.Item2);
            zahl = useCases.OperandErweitern('3');
            Assert.AreEqual(3, zahl);
            result = useCases.Rechnen();
            Assert.IsTrue(result.Item1);
            Assert.AreEqual(95, result.Item2);
        }
    }
}
