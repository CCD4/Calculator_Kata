using System;

namespace Calculator
{
    public interface IUseCases
    {
        double OperandErweitern(int ziffer);
        Tuple<bool, double> Rechnen(Operator newOperator);
        Tuple<bool, double> Rechnen();
    }

    public class UseCases : IUseCases
    {
        private readonly Calculator calculator;

        public UseCases()
        {
            calculator = new Calculator();
        }

        public double OperandErweitern(int ziffer)
        {
            calculator.Anhängen(ziffer);
            return calculator.Operand;
        }

        public Tuple<bool, double> Rechnen(Operator newOperator)
        {
            var success = calculator.OperatorAuswerten(newOperator);
            return new Tuple<bool, double>(success, calculator.Zwischenergebnis);
        }

        public Tuple<bool, double> Rechnen()
        {
            var success = calculator.OperatorAuswerten(Operator.Plus);
            return new Tuple<bool, double>(success, calculator.Zwischenergebnis);
        }
    }
}