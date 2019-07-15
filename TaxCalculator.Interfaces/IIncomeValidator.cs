using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Interfaces
{
    public interface IIncomeValidator
    {
        void Validate(double income);
    }
}
