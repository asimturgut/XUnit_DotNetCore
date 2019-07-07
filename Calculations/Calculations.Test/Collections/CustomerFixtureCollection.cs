using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculations.Test
{
    [CollectionDefinition("Customer")]
    public class CustomerFixtureCollection : ICollectionFixture<CustomerFixture>
    {
    }
}
