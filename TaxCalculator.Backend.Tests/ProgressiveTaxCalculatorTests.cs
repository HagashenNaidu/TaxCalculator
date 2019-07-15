using Moq;
using NUnit.Framework;
using System;
using TaxCalculator.Interfaces;
using TaxCalculator.Services;

namespace TaxCalculator.Backend.Tests
{
    public class ProgressiveTaxCalculatorTests
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
                new ProgressiveTaxCalculator(null);
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
            var progressiveTaxCalculator = new ProgressiveTaxCalculator(mockValidator.Object);
            //--------Execute---------------------------
            progressiveTaxCalculator.Calculate(-12547d);
            //--------Assert----------------------------
            mockValidator.Verify(m => m.Validate(-12547d), Times.Once);
        }

        [TestCase(0         ,0d         ,TestName = "Given Annual Income of 0 Should be 0 Tax")]
        [TestCase(3750      ,375d       ,TestName = "Given Annual Income of 3750 Should be 375 Tax")]
        [TestCase(8340      ,834d       ,TestName = "Given Annual Income of 8340 Should be 834 Tax")]
        [TestCase(8350      ,835d       ,TestName = "Given Annual Income of 8350 Should be 835 Tax")]
        [TestCase(8360      ,836.35d    ,TestName = "Given Annual Income of 8360 Should be 836.35 Tax")]
        [TestCase(9000      ,932.35d    ,TestName = "Given Annual Income of 9000 Should be 932.35 Tax")]
        [TestCase(33950     ,4674.85d   ,TestName = "Given Annual Income of 33950 Should be 4674.85 Tax")]
        [TestCase(62580     ,11832.1d   ,TestName = "Given Annual Income of 62580 Should be 11832.1 Tax")]
        [TestCase(90000     ,18919.32d  ,TestName = "Given Annual Income of 90000 Should be 18919.32 Tax")]
        [TestCase(100000    ,21719.32d  ,TestName = "Given Annual Income of 100000 Should be 21719.32 Tax")]
        [TestCase(150000    ,35719.32d  ,TestName = "Given Annual Income of 150000 Should be 35719.32 Tax")]
        [TestCase(185000    ,46191.49d  ,TestName = "Given Annual Income of 185000 Should be 46191.49 Tax")]
        [TestCase(372950    ,108214.99d ,TestName = "Given Annual Income of 372950 Should be 108214.99 Tax")]
        [TestCase(500000    ,152682.14d, TestName = "Given Annual Income of 500000 Should be 152682.14 Tax")]
        [TestCase(1000000   ,327682.14d ,TestName = "Given Annual Income of 1000000 Should be 327682.14 Tax")]
        public void Given_AnnumIncome(double annualIncome, double expectedTax)
        {
            //----------Setup---------------------------
            var progressiveTaxCalculator = new ProgressiveTaxCalculator(new Mock<IIncomeValidator>().Object);
            //--------Execute---------------------------
            var tax = progressiveTaxCalculator.Calculate(annualIncome);
            //--------Assert----------------------------
            Assert.AreEqual(expectedTax, tax);
        }

   }
}