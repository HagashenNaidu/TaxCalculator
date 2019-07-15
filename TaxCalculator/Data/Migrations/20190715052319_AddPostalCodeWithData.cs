using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TaxCalculator.Data.Migrations
{
    public partial class AddPostalCodeWithData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("PostalCode", table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Code = table.Column<string>(nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PostalCode", x => x.Id);
            }
            );

            migrationBuilder.InsertData("PostalCode", new string[] { "Id", "Code" }, new object[,] { { Guid.NewGuid(), "7441" }, { Guid.NewGuid(), "A100" }, { Guid.NewGuid(), "7000" }, { Guid.NewGuid(), "1000" } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
