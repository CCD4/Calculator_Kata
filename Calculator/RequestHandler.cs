namespace Calculator
{
    public class RequestHandler
    {
        private readonly Calculator calculator;

        public RequestHandler() : this(new Calculator())
        {
        }

        internal RequestHandler(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public double Operand => calculator.Operand;

        public double Zwischenergebnis => calculator.Zwischenergebnis;

        public void ZifferAnhängen(char ziffer)
        {
            var decziffer = double.Parse(ziffer.ToString());
            calculator.Anhängen(decziffer);
        }

        public bool OperatorAuswerten(Operator @operator)
        {
            return calculator.OperatorAuswerten(@operator);
        }

        public bool Berechnen()
        {
            return calculator.OperatorAuswerten(Operator.Plus);
        }
    }
}