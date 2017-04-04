using Calculator;

namespace CalculatorGUI
{
    public class OperatorEventArgs
    {
        public Operator Operator { get; }

        public OperatorEventArgs(Operator @operator)
        {
            Operator = @operator;
        }
    }
}