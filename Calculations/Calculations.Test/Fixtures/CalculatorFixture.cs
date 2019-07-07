using System;
using System.Collections.Generic;
using System.Text;

namespace Calculations.Test
{
    public class CalculatorFixture:IDisposable
    {
        public CalculatorFixture()
        {
            Calc = new Calculator();
        }
        public Calculator Calc { get; set; }

        public void Dispose()
        {
            //dispose...
        }
    }
}
