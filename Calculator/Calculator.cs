using System;

namespace Calculator
{
    public class Calculator
    {
        private  State state;

        public Calculator() : this(new State())
        {
        }

        internal Calculator(State state)
        {
            this.state = state;
        }

        public double Operand => state.Operand;
        public double Zwischenergebnis => state.Zwischenergebnis;
        private Operator LastOperator => state.LastOperator;

        public void Anhängen(int ziffer)
        {
      
            state.Operand = state.Operand*10 + ziffer;
        }

        public bool OperatorAuswerten(Operator @operator)
        {
            var success = true;
            Rechenwerk.Rechnen(Zwischenergebnis, LastOperator, Operand,
                ergebnis =>
                {
                    state = new State(0,@operator,ergebnis);
                },
                () => success = false);
            return success;
        }

        internal class State
        {
            public double Operand { get; set; }

            public Operator LastOperator { get; }
            public double Zwischenergebnis { get; }

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