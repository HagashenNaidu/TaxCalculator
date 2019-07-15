using Moq;
using NUnit.Framework;
using TaxCalculator.Interfaces;
using TaxCalculator.Services;

namespace TaxCalculator.Services.Tests
{
    public class PostalCodeTaxResolverTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Given_PostalCodeTaxResolver_Should_StartWith_4TaxCalculators()
        {
            //-------------------Setup---------------------------------------
            //--------------------Execute------------------------------------
            var postalTaxResolver = new PostalCodeTaxResolver(new Mock<IIncomeValidator>().Object);
            //--------------------Assert-------------------------------------
            Assert.AreEqual(4, postalTaxResolver.Count());
            Assert.IsInstanceOf<ProgressiveTaxCalculator>(postalTaxResolver.GetTaxCalculator("7441"));
            Assert.IsInstanceOf<FlatValueTaxCalculator>(postalTaxResolver.GetTaxCalculator("A100"));
            Assert.IsInstanceOf<FlatRateTaxCalculator>(postalTaxResolver.GetTaxCalculator("7000"));
            Assert.IsInstanceOf<ProgressiveTaxCalculator>(postalTaxResolver.GetTaxCalculator("1000"));
        }

        [Test]
        public void Given_RegisterTaxCalculator_When_Id_DoesNot_Exist_Should_AddTaxCalculator()
        {
            //------------Setup---------------------------------
            var taxCalculator = new FlatRateTaxCalculator(new Mock<IIncomeValidator>().Object);
            const string identifier = "Flat Rate";
            var taxResolver = new PostalCodeTaxResolver(new Mock<IIncomeValidator>().Object);
            //------------Execute--------------------------------
            taxResolver.RegisterTaxCalculator(identifier, taxCalculator);
            //------------Assert--------------------------------
            var numberOfTaxResolvers = taxResolver.Count();
            Assert.AreEqual(5, numberOfTaxResolvers);
            
        }

        [Test]
        public void Given_RegisterTaxCalculator_When_Id_Does_Exist_ShouldNot_AddTaxCalculator()
        {
            //------------Setup---------------------------------
            var taxCalculator = new FlatRateTaxCalculator(new Mock<IIncomeValidator>().Object);
            const string identifier = "Flat Rate";
            var taxResolver = new PostalCodeTaxResolver(new Mock<IIncomeValidator>().Object);
            taxResolver.RegisterTaxCalculator(identifier, taxCalculator);
            //------------Execute--------------------------------
            taxResolver.RegisterTaxCalculator(identifier, taxCalculator);
            //------------Assert--------------------------------
            var numberOfTaxResolvers = taxResolver.Count();
            Assert.AreEqual(5, numberOfTaxResolvers);

        }


        [Test]
        public void Given_GetTaxCalculator_When_Id_Does_Exist_Should_ReturnTaxCalculator()
        {
            //------------Setup---------------------------------
            var taxCalculator = new FlatRateTaxCalculator(new Mock<IIncomeValidator>().Object);
            const string identifier = "Flat Rate";
            var taxResolver = new PostalCodeTaxResolver(new Mock<IIncomeValidator>().Object);
            taxResolver.RegisterTaxCalculator(identifier, taxCalculator);
            //------------Execute--------------------------------
            var returnedTaxCalculator = taxResolver.GetTaxCalculator(identifier);
            //------------Assert--------------------------------
            Assert.AreEqual(taxCalculator, returnedTaxCalculator);

        }

        [Test]
        public void Given_GetTaxCalculator_When_Id_DoesNot_Exist_Should_ThrowException()
        {
            //------------Setup---------------------------------
            var taxCalculator = new FlatRateTaxCalculator(new Mock<IIncomeValidator>().Object);
            const string identifier = "Flat Rate";
            var taxResolver = new PostalCodeTaxResolver(new Mock<IIncomeValidator>().Object);
            taxResolver.RegisterTaxCalculator(identifier, taxCalculator);
            //------------Execute--------------------------------
            try
            {
                taxResolver.GetTaxCalculator("SomeRandomTaxCalculator");
            }
            catch (System.Exception e)
            {
                //------------Assert--------------------------------
                Assert.AreEqual("No Tax Calculator found", e.Message);
            }
        }
    }
}