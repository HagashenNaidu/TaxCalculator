using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaxCalculator.Data;
using TaxCalculator.Data.Models;
using TaxCalculator.Interfaces;

namespace TaxCalculator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ITaxResolver _taxResolver;

        public IndexModel(ApplicationDbContext context, ITaxResolver taxResolver)
        {
            _context = context;
            _taxResolver = taxResolver;
            PostalCodes = context.PostalCode.Select(a =>
                                 new SelectListItem
                                 {
                                     Value = a.Code,
                                     Text = a.Code
                                 }).ToList();
        }

        public List<SelectListItem> PostalCodes { get; set; }
        public IList<UserTaxCalculation> UserCalculations { get; set; }

        [BindProperty]
        public UserTaxCalculation UserCalculation { get; set; }
        public async Task OnGet()
        {
            UserCalculations = await _context.UserTaxCalculation.ToAsyncEnumerable().ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var calculation = _taxResolver.GetTaxCalculator(UserCalculation.PostalCode).Calculate(UserCalculation.AnnualIncome);
            UserCalculation.Id = Guid.NewGuid();
            UserCalculation.CalculationDate = DateTime.Now;
            UserCalculation.TaxCalculation = calculation;
            _context.UserTaxCalculation.Add(UserCalculation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
