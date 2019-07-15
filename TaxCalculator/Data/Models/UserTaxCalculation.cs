using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculator.Data.Models
{
    public class UserTaxCalculation
    {
        public Guid Id { get; set; }

        [Display(Name ="Email")]
        [Required]
        public string EmailAddress { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Calculated")]
        public DateTime CalculationDate { get; set; }

        [Display(Name = "Postal Code")]
        [Required]
        public string PostalCode { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Tax Payable")]
        public double TaxCalculation { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Annual Income")]
        public double AnnualIncome { get; set; }
    }
}
