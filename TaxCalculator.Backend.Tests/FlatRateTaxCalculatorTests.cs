using NUnit.Framework;

namespace TaxCalculator.Services.Tests
{
    public class FlatRateTaxCalculatorTests
    {
        [SetUp]
        public void Setup()
        {
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
        public void Given_AnnumIncome_LessThan_0_ShouldReturn_0()
        {
            //----------Setup---------------------------
            const double annualIncome = -14578d;
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