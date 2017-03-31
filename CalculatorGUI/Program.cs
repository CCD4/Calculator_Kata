using System;
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
            Action<int, Action<double>> onZifferEingegeben = (int ziffer, Action<double> ausgabe) =>
            {
                var ergebnis = useCases.OperandErweitern(ziffer);
                ausgabe(ergebnis);
            };
            Action<Operator, Action<Tuple<bool, double>>> onOperatorEingegeben = (@operator, onBerechnungsErgebnis) =>
            {
                var ergebnis = useCases.Rechnen(@operator);
                onBerechnungsErgebnis(ergebnis);
            };
            Action<Action<Tuple<bool, double>>> onIstGleichEingegeben = (onBerechnungsErgebnis) =>
            {
                var ergebnis = useCases.Rechnen();
                onBerechnungsErgebnis(ergebnis);
            };
            var formCalculator = new FormCalculator(onZifferEingegeben, onOperatorEingegeben, onIstGleichEingegeben);
            Application.Run(formCalculator);
        }
    }
}
