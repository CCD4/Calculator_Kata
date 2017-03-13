using NUnit.Framework;


namespace Calculator
{
    [TestFixture]
    public class RequestHandlerTests
    {
        [Test]
        public void TestZiffernAnhängen()
        {
            var calculator = new Calculator(new Calculator.State {Operand = 12});
            var requestHandler = new RequestHandler(calculator);
            requestHandler.ZifferAnhängen('3');
            Assert.AreEqual(123, requestHandler.Operand);
        }
    }
}
