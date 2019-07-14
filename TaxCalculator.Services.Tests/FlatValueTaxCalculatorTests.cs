using NUnit.Framework;

namespace TaxCalculator.Services.Tests
{
    public class FlatValueTaxCalculatorTests
    {
        [SetUp]
        public void Setup()
        {
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

        [Test]
        public void Given_AnnumIncome_LessThan_0_ShouldReturn_0()
        {
            //----------Setup---------------------------
            const double annualIncome = -23412d;
            var flatValueTaxCalculator = new FlatValueTaxCalculator();
            //--------Execute---------------------------
            var tax = flatValueTaxCalculator.Calculate(annualIncome);
            //--------Assert----------------------------
            Assert.AreEqual(0, tax);
        }
    }
}