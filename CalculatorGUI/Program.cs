using System;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;
using Calculator;

namespace CalculatorGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var useCases = new UseCases();
            var formCalculator = new FormCalculator();
            formCalculator.IstGleichEingegeben += (sender, args) =>
            {
                var ergebnis = useCases.Rechnen();
                formCalculator.BerechnungAuswerten(ergebnis);
            };
            formCalculator.ZifferEingegeben += (sender, args) =>
            {
                var ergebnis = useCases.OperandErweitern(args.Ziffer);
                formCalculator.ErgebnisAnzeigen(ergebnis);
            };
            formCalculator.OperatorEingegeben += (sender, args) =>
            {
                var ergebnis = useCases.Rechnen(args.Operator);
                formCalculator.BerechnungAuswerten(ergebnis);
            };

            Application.Run(formCalculator);

        }
    }
}
