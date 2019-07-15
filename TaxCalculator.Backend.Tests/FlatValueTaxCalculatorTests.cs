using Moq;
using NUnit.Framework;
using System;
using TaxCalculator.Interfaces;
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
        public void Given_Constructor_When_IncomeValidator_Null_Should_ThrowException()
        {
            //----------Setup---------------------------

            //--------Execute---------------------------
            try
            {
                new FlatValueTaxCalculator(null);
            }
            catch (ArgumentNullException e)
            {
                //--------Assert----------------------------
                Assert.AreEqual("Value cannot be null.\r\nParameter name: incomeValidator", e.Message);
            }
        }

        [Test]
        public void Given_Calculate_Should_Call_IncomeValidator_Validate()
        {
            //----------Setup---------------------------
            var mockValidator = new Mock<IIncomeValidator>();
            mockValidator.Setup(m => m.Validate(It.IsAny<double>()));
            var progressiveTaxCalculator = new FlatValueTaxCalculator(mockValidator.Object);
            //--------Execute---------------------------
            progressiveTaxCalculator.Calculate(-12547d);
            //--------Assert----------------------------
            mockValidator.Verify(m => m.Validate(-12547d), Times.Once);
        }



        [Test]
        public void Given_AnnumIncome_EqualTo_200000_ShouldReturn_10000()
        {
            //----------Setup---------------------------
            const double annualIncome = 200000d;
            var flatValueTaxCalculator = new FlatValueTaxCalculator(new Mock<IIncomeValidator>().Object);
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
            var flatValueTaxCalculator = new FlatValueTaxCalculator(new Mock<IIncomeValidator>().Object);
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
            var flatValueTaxCalculator = new FlatValueTaxCalculator(new Mock<IIncomeValidator>().Object);
            //--------Execute---------------------------
            var tax = flatValueTaxCalculator.Calculate(annualIncome);
            //--------Assert----------------------------
            Assert.AreEqual(5000d, tax);
        }

    }
}