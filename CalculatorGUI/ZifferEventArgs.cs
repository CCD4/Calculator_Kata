using System;

namespace CalculatorGUI
{
    public class ZifferEventArgs : EventArgs
    {
        public int Ziffer { get; }

        public ZifferEventArgs(int ziffer)
        {
            Ziffer = ziffer;
        }
    }
}