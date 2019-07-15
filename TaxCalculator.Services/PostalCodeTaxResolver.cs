using TaxCalculator.Interfaces;

namespace TaxCalculator.Services
{
    public class PostalCodeTaxResolver : TaxResolver
    {
        public PostalCodeTaxResolver(IIncomeValidator incomeValidator)
        {
            RegisterTaxCalculator("7441", new ProgressiveTaxCalculator(incomeValidator));
            RegisterTaxCalculator("A100", new FlatValueTaxCalculator(incomeValidator));
            RegisterTaxCalculator("7000", new FlatRateTaxCalculator(incomeValidator));
            RegisterTaxCalculator("1000", new ProgressiveTaxCalculator(incomeValidator));
        }
    }
}
