using System;
using System.Collections.Generic;
using System.Text;

namespace Calculations
{
    public static class CustomerFactory
    {
        public static Customer CreateCustomer(int orderCount)
        {
            if (orderCount <= 100)
            {
                return new Customer();
            }
            else
            {
                return new LoyalCustomer();
            }
        }
    }
}
