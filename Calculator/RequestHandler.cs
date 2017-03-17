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

                if (@operator == Operator.IstGleich)
                    calculator.UpdateLastOperator(Operator.Plus);
                else
                    calculator.UpdateLastOperator(@operator);
            }

            return success;
        }
    }
}