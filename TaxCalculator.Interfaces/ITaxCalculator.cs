using System;

namespace TaxCalculator.Interfaces
{
    public interface ITaxCalculator
    {
        double Calculate(double annualIncome);
    }
}
