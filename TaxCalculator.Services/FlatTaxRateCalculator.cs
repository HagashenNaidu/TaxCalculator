using System;

namespace TaxCalculator.Services
{
    public class FlatTaxRateCalculator
    {
        private const decimal FLAT_PERCENT_RATE = 0.05m;

        public FlatTaxRateCalculator()
        {
        }

        public decimal Calculate(decimal annualIncome)
        {
            if (annualIncome > 200000)
            {
                return 10000m;
            }
            return annualIncome < 0 ? 0 : annualIncome * FLAT_PERCENT_RATE;
        }
    }
}