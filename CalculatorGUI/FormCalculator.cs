using System;
using System.Globalization;
using System.Windows.Forms;
using Calculator;

namespace CalculatorGUI
{
    public partial class FormCalculator : Form
    {
        private readonly UseCases useCases;

        public FormCalculator()
        {
            InitializeComponent();
            useCases = new UseCases();
        }

        private void Ziffer_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var ziffer = button.Text[0];
            double operandErweitern = useCases.OperandErweitern(ziffer);
            textBoxZiffern.Text = operandErweitern.ToString(CultureInfo.CurrentCulture);
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var operatorChar = button.Text[0];
            var @operator = OperatorKonvertieren(operatorChar);

            Tuple<bool, double> result = useCases.Rechnen(@operator);
            BerechnungAuswerten(result);
        }

        private void IstGleich_Click(object sender, EventArgs e)
        {
            Tuple<bool, double> result = useCases.Rechnen();
            BerechnungAuswerten(result);
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
