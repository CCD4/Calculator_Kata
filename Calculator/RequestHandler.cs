namespace Calculator
{
    public class RequestHandler
    {
        private readonly Calculator calculator;

        public RequestHandler() : this(new Calculator()){}

        internal RequestHandler(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public double Operand => calculator.Operand;

        public void ZifferAnhängen(char ziffer)
        {
            var decziffer = double.Parse(ziffer.ToString());
            calculator.Anhängen(decziffer);
        }
    }
}