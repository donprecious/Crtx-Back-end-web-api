using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrExtApiCore.Migrations
{
    public partial class addedPackageRoleContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageRole_Packages_PackageIdId",
                table: "PackageRole");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageRole_PackagesRoles_PackagesRolesId",
                table: "PackageRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackageRole_PackageRoleId",
                table: "Packages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackageRole",
                table: "PackageRole");

            migrationBuilder.RenameTable(
                name: "PackageRole",
                newName: "PackageRoles");

            migrationBuilder.RenameIndex(
                name: "IX_PackageRole_PackagesRolesId",
                table: "PackageRoles",
                newName: "IX_PackageRoles_PackagesRolesId");

            migrationBuilder.RenameIndex(
                name: "IX_PackageRole_PackageIdId",
                table: "PackageRoles",
                newName: "IX_PackageRoles_PackageIdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackageRoles",
                table: "PackageRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageRoles_Packages_PackageIdId",
                table: "PackageRoles",
                column: "PackageIdId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageRoles_PackagesRoles_PackagesRolesId",
                table: "PackageRoles",
                column: "PackagesRolesId",
                principalTable: "PackagesRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_PackageRoles_PackageRoleId",
                table: "Packages",
                column: "PackageRoleId",
                principalTable: "PackageRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageRoles_Packages_PackageIdId",
                table: "PackageRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageRoles_PackagesRoles_PackagesRolesId",
                table: "PackageRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackageRoles_PackageRoleId",
                table: "Packages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackageRoles",
                table: "PackageRoles");

            migrationBuilder.RenameTable(
                name: "PackageRoles",
                newName: "PackageRole");

            migrationBuilder.RenameIndex(
                name: "IX_PackageRoles_PackagesRolesId",
                table: "PackageRole",
                newName: "IX_PackageRole_PackagesRolesId");

            migrationBuilder.RenameIndex(
                name: "IX_PackageRoles_PackageIdId",
                table: "PackageRole",
                newName: "IX_PackageRole_PackageIdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackageRole",
                table: "PackageRole",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageRole_Packages_PackageIdId",
                table: "PackageRole",
                column: "PackageIdId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageRole_PackagesRoles_PackagesRolesId",
                table: "PackageRole",
                column: "PackagesRolesId",
                principalTable: "PackagesRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_PackageRole_PackageRoleId",
                table: "Packages",
                column: "PackageRoleId",
                principalTable: "PackageRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
