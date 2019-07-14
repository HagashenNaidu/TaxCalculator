using System;
using TaxCalculator.Interfaces;

namespace TaxCalculator.Services
{
    public class FlatValueTaxCalculator : ITaxCalculator
    {
        private const double FLAT_PERCENT_RATE = 0.05d;

        public FlatValueTaxCalculator()
        {
        }

        public double Calculate(double annualIncome)
        {
            if (annualIncome > 200000)
            {
                return 10000f;
            }
            return annualIncome <= 0 ? 0 : Math.Round(annualIncome * FLAT_PERCENT_RATE,2);
        }
    }
}