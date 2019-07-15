using Moq;
using NUnit.Framework;
using System;
using TaxCalculator.Interfaces;
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
        public void Given_Constructor_When_IncomeValidator_Null_Should_ThrowException()
        {
            //----------Setup---------------------------

            //--------Execute---------------------------
            try
            {
                new FlatRateTaxCalculator(null);
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
            var progressiveTaxCalculator = new FlatRateTaxCalculator(mockValidator.Object);
            //--------Execute---------------------------
            progressiveTaxCalculator.Calculate(-12547d);
            //--------Assert----------------------------
            mockValidator.Verify(m => m.Validate(-12547d), Times.Once);
        }



        [Test]
        public void Given_AnnumIncome_EqualTo_0_ShouldReturn_0()
        {
            //----------Setup---------------------------
            const double annualIncome = 0d;
            var flatRateTaxCalculator = new FlatRateTaxCalculator(new Mock<IIncomeValidator>().Object);
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
            var flatRateTaxCalculator = new FlatRateTaxCalculator(new Mock<IIncomeValidator>().Object);
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
            var flatRateTaxCalculator = new FlatRateTaxCalculator(new Mock<IIncomeValidator>().Object);
            //--------Execute---------------------------
            var tax = flatRateTaxCalculator.Calculate(annualIncome);
            //--------Assert----------------------------
            Assert.AreEqual(11182.50d, tax);
        }
    }
}