using System;

namespace Calculator
{
    public class UseCases
    {
        private readonly RequestHandler requestHandler;

        public UseCases()
        {
            requestHandler = new RequestHandler();
        }

        public double OperandErweitern(char ziffer)
        {
            requestHandler.ZifferAnhängen(ziffer);
            return requestHandler.Operand;
        }

        public Tuple<bool, double> Rechnen(Operator @operator)
        {
            var success = requestHandler.OperatorAuswerten(@operator);
            return new Tuple<bool, double>(success, requestHandler.Zwischenergebnis);
        }
    }
}