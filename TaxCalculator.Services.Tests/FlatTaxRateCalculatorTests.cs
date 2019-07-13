using NUnit.Framework;

namespace TaxCalculator.Services.Tests
{
    public class FlatTaxRateCalculatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Given_AnnumIncome_EqualTo_200000_ShouldReturn_10000()
        {
            //----------Setup---------------------------
            const decimal annualIncome = 200000m;
            var flatTaxRateCalculator = new FlatTaxRateCalculator();
            //--------Execute---------------------------
            var tax = flatTaxRateCalculator.Calculate(annualIncome);
            //--------Assert----------------------------
            Assert.AreEqual(10000, tax);
        }

        [Test]
        public void Given_AnnumIncome_GreaterThan_200000_ShouldReturn_10000()
        {
            //----------Setup---------------------------
            const decimal annualIncome = 500000m;
            var flatTaxRateCalculator = new FlatTaxRateCalculator();
            //--------Execute---------------------------
            var tax = flatTaxRateCalculator.Calculate(annualIncome);
            //--------Assert----------------------------
            Assert.AreEqual(10000, tax);
        }

        [Test]
        public void Given_AnnumIncome_LessThan_200000_ShouldReturn_5PercentOfValue()
        {
            //----------Setup---------------------------
            const decimal annualIncome = 100000m;
            var flatTaxRateCalculator = new FlatTaxRateCalculator();
            //--------Execute---------------------------
            var tax = flatTaxRateCalculator.Calculate(annualIncome);
            //--------Assert----------------------------
            Assert.AreEqual(5000, tax);
        }

        [Test]
        public void Given_AnnumIncome_LessThan_0_ShouldReturn_0()
        {
            //----------Setup---------------------------
            const decimal annualIncome = -23412m;
            var flatTaxRateCalculator = new FlatTaxRateCalculator();
            //--------Execute---------------------------
            var tax = flatTaxRateCalculator.Calculate(annualIncome);
            //--------Assert----------------------------
            Assert.AreEqual(0, tax);
        }
    }
}