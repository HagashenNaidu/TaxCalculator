using System;
using TaxCalculator.Interfaces;

namespace TaxCalculator.Services
{
    public class FlatRateTaxCalculator : ITaxCalculator
    {
        private const double FLAT_PERCENT_RATE = 0.175d;

        public FlatRateTaxCalculator()
        {
        }

        public double Calculate(double annualIncome)
        {
            if(annualIncome <= 0) return 0;
            return Math.Round(annualIncome * FLAT_PERCENT_RATE,2);
        }
    }
}
