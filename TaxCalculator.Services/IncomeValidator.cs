using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Services
{
    public static class IncomeValidator
    {
        public static void Validate(double annualIncome)
        {
            if (annualIncome < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(annualIncome), "Annual Income cannot be less than 0");
            }
            if (annualIncome > double.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(annualIncome), $"Annual Income cannot be more than {double.MaxValue}");
            }
        }
    }
}
