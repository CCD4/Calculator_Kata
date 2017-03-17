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

        public Tuple<bool, double> Rechnen(Operator newOperator)
        {
            var success = requestHandler.OperatorAuswerten(newOperator);
            return new Tuple<bool, double>(success, requestHandler.Zwischenergebnis);
        }

        public Tuple<bool, double> Rechnen()
        {
            var success = requestHandler.Berechnen();
            return new Tuple<bool, double>(success, requestHandler.Zwischenergebnis);
        }
    }
}