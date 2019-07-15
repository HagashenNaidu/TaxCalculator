using System;
using System.Collections.Generic;
using TaxCalculator.Interfaces;

namespace TaxCalculator.Services
{
    public abstract class TaxResolver : ITaxResolver
    {
        Dictionary<string, ITaxCalculator> _taxCalculators = new Dictionary<string, ITaxCalculator>();

        public ITaxCalculator GetTaxCalculator(string identifier)
        {
            if (!_taxCalculators.ContainsKey(identifier))
            {
                throw new Exception("No Tax Calculator found");
            }
            return _taxCalculators[identifier];
        }
        public void RegisterTaxCalculator(string identifier, ITaxCalculator taxCalculator)
        {
            if (!_taxCalculators.ContainsKey(identifier))
            {
                _taxCalculators.Add(identifier, taxCalculator);
            }
        }

        public int Count()
        {
            return _taxCalculators.Count;
        }
    }
}
