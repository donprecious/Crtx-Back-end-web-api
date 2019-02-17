using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrExtApiCore.Migrations
{
    public partial class updatePackageRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PackagesRolesId",
                table: "Packages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_PackagesRolesId",
                table: "Packages",
                column: "PackagesRolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_PackagesRoles_PackagesRolesId",
                table: "Packages",
                column: "PackagesRolesId",
                principalTable: "PackagesRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackagesRoles_PackagesRolesId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_PackagesRolesId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "PackagesRolesId",
                table: "Packages");
        }
    }
}
