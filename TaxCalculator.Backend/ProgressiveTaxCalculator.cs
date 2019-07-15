using System;
using System.Collections.Generic;
using TaxCalculator.Interfaces;
using System.Linq;

namespace TaxCalculator.Services
{

    public class ProgressiveTaxCalculator : ITaxCalculator
    {
        readonly List<(double minimum, double maximum, double rate)> _taxBrackets = new List<(double minimum, double maximum, double rate)>
        {
            (minimum:0d       ,maximum:8350d            ,rate:0.1d),
            (minimum:8351d    ,maximum:33950d           ,rate:0.15d),
            (minimum:33951d   ,maximum:82250d           ,rate:0.25d),
            (minimum:82251d   ,maximum:171550d          ,rate:0.28d),
            (minimum:171551d  ,maximum:372950d          ,rate:0.33d),
            (minimum:372951d  ,maximum:double.MaxValue  ,rate:0.35d),

        };
        private readonly IIncomeValidator _incomeValidator;

        public ProgressiveTaxCalculator(IIncomeValidator incomeValidator)
        {
            _incomeValidator = incomeValidator ?? throw new ArgumentNullException(nameof(incomeValidator));
        }

        public double Calculate(double annualIncome)
        {
            _incomeValidator.Validate(annualIncome);
            var taxToBePaid = 0d;
            foreach (var bracketTax in GetBracketTax(annualIncome))
            {
                taxToBePaid += bracketTax;
            }
            return Math.Round(taxToBePaid,2);
        }

        private IEnumerable<double> GetBracketTax(double annualIncome) => from bracket in _taxBrackets
                                                                      where annualIncome > bracket.minimum
                                                                      let incomeInTheBracket = Math.Min(bracket.maximum - bracket.minimum, annualIncome - bracket.minimum)
                                                                      let bracketTax = incomeInTheBracket * bracket.rate
                                                                      select bracketTax;
    }
}