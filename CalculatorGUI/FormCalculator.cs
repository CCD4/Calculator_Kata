using System;
using System.Globalization;
using System.Windows.Forms;
using Calculator;

namespace CalculatorGUI
{
    public partial class FormCalculator : Form
    {
        public FormCalculator()
        {
            InitializeComponent();
        }

        public event EventHandler IstGleichEingegeben;
        public event EventHandler<ZifferEventArgs> ZifferEingegeben;
        public event EventHandler<OperatorEventArgs> OperatorEingegeben;

        private void Ziffer_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            int ziffer = int.Parse(button.Text);
            ZifferEingegeben?.Invoke(this, new ZifferEventArgs(ziffer));
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var operatorChar = button.Text[0];
            var @operator = OperatorKonvertieren(operatorChar);
            OperatorEingegeben?.Invoke(this, new OperatorEventArgs(@operator));
        }

        private void IstGleich_Click(object sender, EventArgs e)
        {
            IstGleichEingegeben?.Invoke(this, new EventArgs());
        }

        public void ErgebnisAnzeigen(double ergebnis)
        {
            textBoxZiffern.Text = ergebnis.ToString(CultureInfo.CurrentCulture);
        }

        public void BerechnungAuswerten(Tuple<bool, double> result)
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
