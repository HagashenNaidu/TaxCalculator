using System;
using TaxCalculator.Interfaces;

namespace TaxCalculator.Services
{
    public class FlatRateTaxCalculator : ITaxCalculator
    {
        private const double FLAT_PERCENT_RATE = 0.175d;
        private readonly IIncomeValidator _incomeValidator;

        public FlatRateTaxCalculator(IIncomeValidator incomeValidator)
        {
            _incomeValidator = incomeValidator ?? throw new ArgumentNullException(nameof(incomeValidator));
        }

        public double Calculate(double annualIncome)
        {
            _incomeValidator.Validate(annualIncome);
            return Math.Round(annualIncome * FLAT_PERCENT_RATE,2);
        }
    }
}
