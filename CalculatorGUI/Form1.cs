using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator;

namespace CalculatorGUI
{
    public partial class FormCalculator : Form
    {
        private UseCases useCases;
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

            Tuple<bool, double> result = useCases.Rechnen(@operator);
            if (result.Item1 == true)
                textBoxZiffern.Text = result.Item2.ToString(CultureInfo.CurrentCulture);
            else
                MessageBox.Show("Fehler");

        }

        private void IstGleich_Click(object sender, EventArgs e)
        {
            Tuple<bool, double> result = useCases.Rechnen();
            if (result.Item1 == true)
                textBoxZiffern.Text = result.Item2.ToString(CultureInfo.CurrentCulture);
            else
                MessageBox.Show("Fehler");

        }
    }
}
