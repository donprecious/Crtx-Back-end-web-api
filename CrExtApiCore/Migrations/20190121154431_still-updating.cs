using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrExtApiCore.Migrations
{
    public partial class stillupdating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageRoles_Packages_PackageIdId",
                table: "PackageRoles");

            migrationBuilder.RenameColumn(
                name: "PackageIdId",
                table: "PackageRoles",
                newName: "PackageId");

            migrationBuilder.RenameIndex(
                name: "IX_PackageRoles_PackageIdId",
                table: "PackageRoles",
                newName: "IX_PackageRoles_PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageRoles_Packages_PackageId",
                table: "PackageRoles",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageRoles_Packages_PackageId",
                table: "PackageRoles");

            migrationBuilder.RenameColumn(
                name: "PackageId",
                table: "PackageRoles",
                newName: "PackageIdId");

            migrationBuilder.RenameIndex(
                name: "IX_PackageRoles_PackageId",
                table: "PackageRoles",
                newName: "IX_PackageRoles_PackageIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageRoles_Packages_PackageIdId",
                table: "PackageRoles",
                column: "PackageIdId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
