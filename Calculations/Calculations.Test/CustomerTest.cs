using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculations.Test
{
    [Collection("Customer")]
    public class CustomerTest //: IClassFixture<CustomerFixture> collection yarattık gerek yok artık
    {
        public CustomerFixture _customerFixture { get; }
        public CustomerTest(CustomerFixture customerFixture)
        {
            _customerFixture = customerFixture;
        }

        [Fact]
        public void CheckNameNotEmpty()
        {
            Customer customer = _customerFixture.Cust;
            Assert.NotNull(customer.Name);
            Assert.False(string.IsNullOrEmpty(customer.Name));
        }

        [Fact]
        public void CheckLegiForDiscount()
        {
            Customer customer = _customerFixture.Cust;
            Assert.InRange(customer.Age, 20, 40);
        }
        [Fact]
        public void GetOrdersByNameNotNull()
        {
            Customer customer = _customerFixture.Cust;

            //Assert.Throws(typeof(ArgumentException),)
            var exceptionDetailt = Assert.Throws<ArgumentException>(() => customer.GetOrdersByName(null));
            Assert.Equal("Hello", exceptionDetailt.Message);
        }

        [Fact]
        public void LocalCustomerForOrdersGreatherThan100()
        {
            var customer = CustomerFactory.CreateCustomer(102);

            var loyalCustomer = Assert.IsType<LoyalCustomer>(customer);

            Assert.Equal(10, loyalCustomer.Discount);
        }
    }
}
