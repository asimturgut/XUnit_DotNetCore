using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculations.Test
{
    [Collection("Customer")]
    public class CustomerDetailsTests
    {
        public CustomerFixture _customerFixture { get; }
        public CustomerDetailsTests(CustomerFixture customerFixture)
        {
            _customerFixture = customerFixture;
        }



        [Fact]
        public void MakeFullNameTest()
        {
            var customer = _customerFixture.Cust;

            var result = customer.GetFullName("Aref", "Karimi");

            Assert.Equal("Aref Karimi", result);
        }
    }
}
