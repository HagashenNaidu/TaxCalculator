using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Interfaces
{
    public interface ITaxResolver
    {
        ITaxCalculator GetTaxCalculator(string identifier);
        void RegisterTaxCalculator(string identifier, ITaxCalculator taxCalculator);
        int Count();
    }
}
