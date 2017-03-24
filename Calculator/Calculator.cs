using System;

namespace Calculator
{
    public class Calculator
    {
        private readonly State state;

        public Calculator() : this(new State()) { }
        internal Calculator(State state) { this.state = state; }

        public double Operand => state.Operand;
        public Operator LastOperator => state.LastOperator;
        public double Zwischenergebnis => state.Zwischenergebnis;

        public void Anhängen(double ziffer)
        {
            state.Operand = state.Operand * 10 + ziffer;
        }


        public bool OperatorAuswerten(Operator @operator)
        {
            var success = Rechnen();

            if (success)
            {
                Reset();
                UpdateLastOperator(@operator);
            }

            return success;
        }

        public bool Rechnen()
        {
            switch (LastOperator)
            {
                case Operator.Plus:
                    state.Zwischenergebnis += state.Operand;
                    break;
                case Operator.Minus:
                    state.Zwischenergebnis -= state.Operand;
                    break;
                case Operator.Mal:
                    state.Zwischenergebnis *= state.Operand;
                    break;
                case Operator.Durch:
                    if(state.Operand == 0)
                        return false;
                    state.Zwischenergebnis /= state.Operand;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(LastOperator.ToString());
            }
            return true;
        }

        internal class State
        {
            public State() : this(0,Operator.Plus, 0)
            {                
            }

            public State(double operand, Operator lastOperator, double zwischenergebnis)
            {
                Operand = operand;
                LastOperator = lastOperator;
                Zwischenergebnis = zwischenergebnis;
            }

            public double Operand;
            public Operator LastOperator;
            public double Zwischenergebnis;
        }

        public void UpdateLastOperator(Operator @operator)
        {
            state.LastOperator = @operator;
        }

        public void Reset()
        {
            state.Operand = 0;
        }
    }
}
