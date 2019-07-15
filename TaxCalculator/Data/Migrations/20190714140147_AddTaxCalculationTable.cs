using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TaxCalculator.Data.Migrations
{
    public partial class AddTaxCalculationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("UserTaxCalculation", table => new
            {
                Id = table.Column<Guid>(nullable:false,defaultValue:Guid.NewGuid()),
                EmailAddress = table.Column<string>(nullable: false,maxLength:450),
                PostalCode = table.Column<string>(nullable: false),
                AnnualIncome = table.Column<double>(nullable:false),
                TaxCalculation = table.Column<double>(nullable: false),
                CalculationDate = table.Column<DateTime>(nullable:false,defaultValue:DateTime.Now)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserCalculation", x => x.Id);
            }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
