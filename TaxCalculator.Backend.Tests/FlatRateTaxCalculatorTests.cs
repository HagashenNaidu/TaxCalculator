using NUnit.Framework;
using System;
using TaxCalculator.Services;

namespace TaxCalculator.Backend.Tests
{
    public class FlatRateTaxCalculatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Given_AnnualIncome_When_LessThan_Zero_ShouldThrowException()
        {
            //----------Setup---------------------------
            var progressiveTaxCalculator = new FlatRateTaxCalculator();
            //--------Execute---------------------------
            try
            {
                progressiveTaxCalculator.Calculate(-12547d);
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
            var progressiveTaxCalculator = new FlatRateTaxCalculator();
            //--------Execute---------------------------
            try
            {
                progressiveTaxCalculator.Calculate(double.MaxValue * 2d);
                Assert.Fail("No exception thrown");
            }
            //--------Assert----------------------------
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.AreEqual($"Annual Income cannot be more than {double.MaxValue}\r\nParameter name: annualIncome", exception.Message);
            }
        }

        [Test]
        public void Given_AnnumIncome_EqualTo_0_ShouldReturn_0()
        {
            //----------Setup---------------------------
            const double annualIncome = 0d;
            var flatRateTaxCalculator = new FlatRateTaxCalculator();
            //--------Execute---------------------------
            var tax = flatRateTaxCalculator.Calculate(annualIncome);
            //--------Assert----------------------------
            Assert.AreEqual(0, tax);
        }

        [Test]
        public void Given_AnnumIncome_100000_ShouldReturn_17500()
        {
            //----------Setup---------------------------
            const double annualIncome = 100000d;
            var flatRateTaxCalculator = new FlatRateTaxCalculator();
            //--------Execute---------------------------
            var tax = flatRateTaxCalculator.Calculate(annualIncome);
            //--------Assert----------------------------
            Assert.AreEqual(17500d, tax);
        }

        [Test]
        public void Given_AnnumIncome_63900_ShouldReturn_PercentageBasedValue()
        {
            //----------Setup---------------------------
            const double annualIncome = 63900d;
            var flatRateTaxCalculator = new FlatRateTaxCalculator();
            //--------Execute---------------------------
            var tax = flatRateTaxCalculator.Calculate(annualIncome);
            //--------Assert----------------------------
            Assert.AreEqual(11182.50d, tax);
        }
    }
}