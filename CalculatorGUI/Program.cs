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
            var formCalculator = new FormCalculator(useCases);
            Application.Run(formCalculator);
        }
    }
}
