using System;

namespace Calculator
{
    public class Calculator
    {
        private readonly State state;

        public Calculator() : this(new State())
        {
        }

        internal Calculator(State state)
        {
            this.state = state;
        }

        public double Operand => state.Operand;
        private Operator LastOperator => state.LastOperator;
        public double Zwischenergebnis => state.Zwischenergebnis;

        public void Anhängen(int ziffer)
        {
            state.Operand = state.Operand * 10 + ziffer;
        }

        public bool OperatorAuswerten(Operator @operator)
        {
            bool success = true;
            Rechnen(
                () => ResetState(@operator),
                () => success = false);
            return success;
        }

        private void ResetState(Operator @operator)
        {
            Reset();
            UpdateLastOperator(@operator);
        }

        internal void Rechnen(Action onSuccess, Action onFailure)
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
                    if (state.Operand == 0)
                    {
                        onFailure();
                        return;                        
                    }
                    state.Zwischenergebnis /= state.Operand;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(LastOperator.ToString());
            }
            onSuccess();
        }

        public void UpdateLastOperator(Operator @operator)
        {
            state.LastOperator = @operator;
        }

        public void Reset()
        {
            state.Operand = 0;
        }

        internal class State
        {
            public Operator LastOperator;

            public double Operand;
            public double Zwischenergebnis;

            public State() : this(0, Operator.Plus, 0)
            {
            }

            public State(double operand, Operator lastOperator, double zwischenergebnis)
            {
                Operand = operand;
                LastOperator = lastOperator;
                Zwischenergebnis = zwischenergebnis;
            }
        }
    }
}