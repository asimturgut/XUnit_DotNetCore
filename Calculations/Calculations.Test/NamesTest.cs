using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculations.Test
{
    public class NamesTest
    {
        [Fact]
        public void MakeFullNameTest()
        {
            var names = new Names();

            var result = names.MakeFullName("Aref", "Karimi");

            Assert.Equal("Aref Karimi", result);
        }

        [Fact]
        public void MakeFullNameIgnoreKeySensitiveTest()
        {
            var names = new Names();

            var result = names.MakeFullName("aref", "Karimi");

            Assert.Equal("Aref Karimi", result, ignoreCase: true);
        }

        [Fact]
        public void MakeFullNameCompareWithContainsTest()
        {
            var names = new Names();

            var result = names.MakeFullName("Aref", "Karimi");

            Assert.Contains("aref", result, StringComparison.InvariantCultureIgnoreCase);
        }

        [Fact]
        public void MakeFullNameCompareWithStartsWithTest()
        {
            var names = new Names();

            var result = names.MakeFullName("Aref", "Karimi");

            Assert.StartsWith("aref", result, StringComparison.InvariantCultureIgnoreCase);
            Assert.EndsWith("Karimi", result, StringComparison.InvariantCultureIgnoreCase);

        }


        [Fact]
        public void MakeFullNameCompareWithReqularExpressionTest()
        {
            var names = new Names();

            var result = names.MakeFullName("Aref", "Karimi");

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", result);
        }


        [Fact]
        public void NickName_MustBeNull()
        {
            var names = new Names();

            Assert.Null(names.NickName);
        }


        [Fact]
        public void MakeFullName_AlwaysReturnValue()
        {
            var names = new Names();

            var result = names.MakeFullName("Aref", "Karimi");

            Assert.NotNull(result);

            Assert.True(!string.IsNullOrEmpty(result));
        }
    }
}
