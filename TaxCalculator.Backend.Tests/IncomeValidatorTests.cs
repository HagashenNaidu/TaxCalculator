using NUnit.Framework;
using System;
using TaxCalculator.Services;

namespace TaxCalculator.Backend.Tests
{
    public class IncomeValidatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Given_AnnualIncome_When_LessThan_Zero_ShouldThrowException()
        {
            //----------Setup---------------------------
            //--------Execute---------------------------
            try
            {
                IncomeValidator.Validate(-12547d);
                Assert.Fail("No exception thrown");
            }
            //--------Assert----------------------------
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.AreEqual("Annual Income cannot be less than 0\r\nParameter name: annualIncome", exception.Message);
            }
        }

        [Test]
        public void Given_AnnualIncome_When_MoreThan_DoubleMax_ShouldThrowException()
        {
            //----------Setup---------------------------
            //--------Execute---------------------------
            try
            {
                IncomeValidator.Validate(double.MaxValue * 2d);
                Assert.Fail("No exception thrown");
            }
            //--------Assert----------------------------
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.AreEqual($"Annual Income cannot be more than {double.MaxValue}\r\nParameter name: annualIncome", exception.Message);
            }
        }
    }
}
