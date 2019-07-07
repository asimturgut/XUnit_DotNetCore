using Calculations.Test.Data.Attribute;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Calculations.Test
{
    public class CalculatorTest : IClassFixture<CalculatorFixture>, IDisposable
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly MemoryStream _memoryStream;

        public CalculatorFixture _calculatorFixture { get; }

        public CalculatorTest(ITestOutputHelper testOutputHelper, CalculatorFixture calculatorFixture)
        {
            _testOutputHelper = testOutputHelper;
            _calculatorFixture = calculatorFixture;
            _testOutputHelper.WriteLine("Constructure");
            _memoryStream = new MemoryStream();
        }

        [Fact]
        public void Test()
        {
            Assert.True(true);
            //Assert.Equal(1, 2);
        }

        [Fact]
        public void Add_GivenTwoIntValues_ReturnsSum()
        {
            var calc = _calculatorFixture.Calc;

            var result = calc.Add(1, 2);

            Assert.Equal(3, result);

        }

        [Fact]
        public void AddDouble_GivenTwoDoubleValues_ReturnsSum()
        {
            var calc = _calculatorFixture.Calc;

            var result = calc.AddDouble(1.2, 3.5);

            Assert.Equal(4.7, result);

        }


        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboDoesNotIncludeZero()
        {
            var calc = _calculatorFixture.Calc;

            Assert.All(calc.FiboNumbers, n => Assert.NotEqual(0, n));

        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboInclude13()
        {
            _testOutputHelper.WriteLine("FiboInclude13 testi baþladý ...");
            var calc = _calculatorFixture.Calc;

            Assert.Contains(13, calc.FiboNumbers);

        }


        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboDoesNotContain4()
        {
            var calc = _calculatorFixture.Calc;

            Assert.DoesNotContain(4, calc.FiboNumbers);

        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void CheckCollection()
        {
            List<int> expectedCollection = new List<int>() { 1, 1, 2, 3, 5, 8, 13 };
            var calc = _calculatorFixture.Calc;

            Assert.Equal(expectedCollection, calc.FiboNumbers);

        }

        [Fact]
        public void IsOdd_GivenOddValue_ReturnTrue()
        {
            var calc = _calculatorFixture.Calc;

            var result = calc.IsOdd(1);

            Assert.True(result);

        }
        [Fact]
        public void IsOdd_GivenEvenValue_ReturnFalse()
        {
            var calc = _calculatorFixture.Calc;

            var result = calc.IsOdd(2);

            Assert.False(result);

        }
        [Theory]
        [InlineData(1, true)]
        [InlineData(200, false)]
        public void IsOdd_TestOddAndEven(int value, bool expected)
        {
            var calc = _calculatorFixture.Calc;

            var result = calc.IsOdd(value);

            Assert.Equal(expected, result);

        }

        [Theory]
        [MemberData(nameof(TestDataShare.IsOddOrEvenData), MemberType = typeof(TestDataShare))]
        public void IsOdd_TestOddAndEvenWithMemberData(int value, bool expected)
        {
            var calc = _calculatorFixture.Calc;

            var result = calc.IsOdd(value);

            Assert.Equal(expected, result);

        }
        [Theory]
        [MemberData(nameof(TestDataShare.IsOddOrEvenDataFromExternalResource), MemberType = typeof(TestDataShare))]
        public void IsOdd_TestOddAndEvenWithMemberDataExternalReource(int value, bool expected)
        {
            var calc = _calculatorFixture.Calc;

            var result = calc.IsOdd(value);

            Assert.Equal(expected, result);

        }
        [Theory]
        [IsOddOrEventTestDataAttribute]
        public void IsOdd_TestOddAndEvenWithMemberDataWithDataAttribute(int value, bool expected)
        {
            var calc = _calculatorFixture.Calc;

            var result = calc.IsOdd(value);

            Assert.Equal(expected, result);

        }

        public void Dispose()
        {
            _memoryStream.Close();
        }
    }
}
