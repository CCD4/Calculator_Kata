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
    }
}
