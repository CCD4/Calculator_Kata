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
            var success = calculator.Rechnen();

            if (success)
            {
                calculator.Reset();
                calculator.UpdateLastOperator(@operator);
            }

            return success;
        }

        public bool Berechnen()
        {
            var success = calculator.Rechnen();
            if (success)
            {
                calculator.Reset();
                calculator.UpdateLastOperator(Operator.Plus);
            }
            return success;
        }
    }
}