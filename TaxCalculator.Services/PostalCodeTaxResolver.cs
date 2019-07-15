namespace TaxCalculator.Services
{
    public class PostalCodeTaxResolver : TaxResolver
    {
        public PostalCodeTaxResolver()
        {
            RegisterTaxCalculator("7441", new ProgressiveTaxCalculator());
            RegisterTaxCalculator("A100", new FlatValueTaxCalculator());
            RegisterTaxCalculator("7000", new FlatRateTaxCalculator());
            RegisterTaxCalculator("1000", new ProgressiveTaxCalculator());
        }
    }
}
