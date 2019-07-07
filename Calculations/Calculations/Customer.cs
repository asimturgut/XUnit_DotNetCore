using System;
using System.Collections.Generic;
using System.Text;

namespace Calculations
{
    public class Customer
    {
        public Customer()
        {
            Age = 35;
            Name = "Aref";
        }
        public int Age { get; set; }
        public string Name { get; set; }
        public virtual int GetOrdersByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Hello");
            }
            return 100;
        }
        public string GetFullName(string firstName, string lastName)
        {
            return $"{firstName} {lastName}";
        }
    }
}
