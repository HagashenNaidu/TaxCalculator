using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaxCalculator.Data.Models;

namespace TaxCalculator.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserTaxCalculation> UserTaxCalculation { get; set; }
        public DbSet<PostalCode> PostalCode { get; set; }
    }
}
