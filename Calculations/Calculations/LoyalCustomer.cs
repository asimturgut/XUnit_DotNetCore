using System;
using System.Collections.Generic;
using System.Text;

namespace Calculations
{
    public class LoyalCustomer : Customer
    {
        public int Discount{ get; set; }
        public LoyalCustomer()
        {
            Discount = 10;
        }
        public override int GetOrdersByName(string name)
        {
            return 101;
        }
    }
}
