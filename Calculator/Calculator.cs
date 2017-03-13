namespace Calculator
{
    public class Calculator
    {
        private readonly State state;

        public Calculator() : this(new State()) { }
        internal Calculator(State state) { this.state = state; }

        public double Operand => state.Operand;

        public void Anhängen(double ziffer)
        {
            state.Operand = state.Operand * 10 + ziffer;
        }

        internal class State
        {
            public double Operand;
        }
    }
}
