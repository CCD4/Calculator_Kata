using System;

namespace Calculator
{
    public class Calculator
    {
        private readonly State state;

        public Calculator() : this(new State()) { }
        internal Calculator(State state) { this.state = state; }

        public double Operand => state.Operand;
        public Operator OperatorAlt => state.OperatorAlt;
        public double Zwischenergebnis => state.Zwischenergebnis;

        public void Anhängen(double ziffer)
        {
            state.Operand = state.Operand * 10 + ziffer;
        }

        public bool Rechnen()
        {
            switch (OperatorAlt)
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
                    state.Zwischenergebnis /= state.Operand;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return !double.IsInfinity(Zwischenergebnis);
        }

        internal class State
        {
            public State() : this(0,Operator.Plus, 0)
            {                
            }
            public State(double operand, Operator operatorAlt, double zwischenergebnis)
            {
                Operand = operand;
                OperatorAlt = operatorAlt;
                Zwischenergebnis = zwischenergebnis;
            }

            public double Operand;
            public Operator OperatorAlt;
            public double Zwischenergebnis;
        }
    }
}
