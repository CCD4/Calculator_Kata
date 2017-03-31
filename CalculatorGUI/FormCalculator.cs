using System;
using System.Globalization;
using System.Windows.Forms;
using Calculator;

namespace CalculatorGUI
{
    public partial class FormCalculator : Form
    {
        private readonly Action<int, Action<double>> onZifferEingegeben;
        private readonly Action<Operator, Action<Tuple<bool, double>>> onOperatorEingegeben;
        private readonly Action<Action<Tuple<bool, double>>> onIstGleichEingegeben;

        public FormCalculator(Action<int, Action<double>> onZifferEingegeben, Action<Operator, Action<Tuple<bool, double>>> onOperatorEingegeben, Action<Action<Tuple<bool, double>>> onIstGleichEingegeben)
        {
            this.onZifferEingegeben = onZifferEingegeben;
            this.onOperatorEingegeben = onOperatorEingegeben;
            this.onIstGleichEingegeben = onIstGleichEingegeben;
            InitializeComponent();
        }

        private void Ziffer_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            int ziffer = int.Parse(button.Text);
            onZifferEingegeben(ziffer, ErgebnisAnzeigen);
        }

        private void ErgebnisAnzeigen(double ergebnis)
        {
            textBoxZiffern.Text = ergebnis.ToString(CultureInfo.CurrentCulture);
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var operatorChar = button.Text[0];
            var @operator = OperatorKonvertieren(operatorChar);
            onOperatorEingegeben(@operator, BerechnungAuswerten);
        }

        private void IstGleich_Click(object sender, EventArgs e)
        {
            onIstGleichEingegeben(BerechnungAuswerten);
        }

        private void BerechnungAuswerten(Tuple<bool, double> result)
        {
            if (result.Item1)
                textBoxZiffern.Text = result.Item2.ToString(CultureInfo.CurrentCulture);
            else
                MessageBox.Show(@"Fehler");
        }

        private static Operator OperatorKonvertieren(char operatorChar)
        {
            Operator @operator;

            switch (operatorChar)
            {
                case '+':
                    @operator = Operator.Plus;
                    break;
                case '-':
                    @operator = Operator.Minus;
                    break;
                case '*':
                    @operator = Operator.Mal;
                    break;
                case '/':
                    @operator = Operator.Durch;
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return @operator;
        }
    }
}
