using System;

namespace Calculator
{
    public class Rechenwerk
    {
        public static void Rechnen(double operand1, Operator @operator, double operand2, Action<double> onSuccess, Action onFailure)
        {
            switch (@operator)
            {
                case Operator.Plus:
                    operand1 += operand2;
                    break;
                case Operator.Minus:
                    operand1 -= operand2;
                    break;
                case Operator.Mal:
                    operand1 *= operand2;
                    break;
                case Operator.Durch:
                    if (operand2 == 0)
                    {
                        onFailure();
                        return;
                    }
                    operand1 /= operand2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(@operator.ToString());
            }
            onSuccess(operand1);
        }
    }
}