using System;
using TaxCalculator.Interfaces;

namespace TaxCalculator.Services
{
    public class FlatValueTaxCalculator : ITaxCalculator
    {
        private const double FLAT_PERCENT_RATE = 0.05d;
        private readonly IIncomeValidator _incomeValidator;

        public FlatValueTaxCalculator(IIncomeValidator incomeValidator)
        {
            _incomeValidator = incomeValidator ?? throw new ArgumentNullException(nameof(incomeValidator));
        }

        public double Calculate(double annualIncome)
        {
            _incomeValidator.Validate(annualIncome);
            if (annualIncome > 200000)
            {
                return 10000f;
            }
            return annualIncome <= 0 ? 0 : Math.Round(annualIncome * FLAT_PERCENT_RATE,2);
        }
    }
}