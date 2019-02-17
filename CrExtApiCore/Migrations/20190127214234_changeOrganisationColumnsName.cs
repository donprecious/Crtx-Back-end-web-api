using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrExtApiCore.Migrations
{
    public partial class changeOrganisationColumnsName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RC_Number",
                table: "Organisations",
                newName: "RCNumber");

            migrationBuilder.RenameColumn(
                name: "Nature_of_Business",
                table: "Organisations",
                newName: "NatureOfBusiness");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RCNumber",
                table: "Organisations",
                newName: "RC_Number");

            migrationBuilder.RenameColumn(
                name: "NatureOfBusiness",
                table: "Organisations",
                newName: "Nature_of_Business");
        }
    }
}
