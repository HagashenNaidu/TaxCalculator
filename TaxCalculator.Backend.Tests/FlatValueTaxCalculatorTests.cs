using NUnit.Framework;
using System;
using TaxCalculator.Services;

namespace TaxCalculator.Backend.Tests
{
    public class FlatValueTaxCalculatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Given_AnnualIncome_When_LessThan_Zero_ShouldThrowException()
        {
            //----------Setup---------------------------
            var progressiveTaxCalculator = new FlatValueTaxCalculator();
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
            var progressiveTaxCalculator = new FlatValueTaxCalculator();
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
        public void Given_AnnumIncome_EqualTo_200000_ShouldReturn_10000()
        {
            //----------Setup---------------------------
            const double annualIncome = 200000d;
            var flatValueTaxCalculator = new FlatValueTaxCalculator();
            //--------Execute---------------------------
            var tax = flatValueTaxCalculator.Calculate(annualIncome);
            //--------Assert----------------------------
            Assert.AreEqual(10000d, tax);
        }

        [Test]
        public void Given_AnnumIncome_GreaterThan_200000_ShouldReturn_10000()
        {
            //----------Setup---------------------------
            const double annualIncome = 500000d;
            var flatValueTaxCalculator = new FlatValueTaxCalculator();
            //--------Execute---------------------------
            var tax = flatValueTaxCalculator.Calculate(annualIncome);
            //--------Assert----------------------------
            Assert.AreEqual(10000d, tax);
        }

        [Test]
        public void Given_AnnumIncome_LessThan_200000_ShouldReturn_5PercentOfValue()
        {
            //----------Setup---------------------------
            const double annualIncome = 100000d;
            var flatValueTaxCalculator = new FlatValueTaxCalculator();
            //--------Execute---------------------------
            var tax = flatValueTaxCalculator.Calculate(annualIncome);
            //--------Assert----------------------------
            Assert.AreEqual(5000d, tax);
        }

    }
}