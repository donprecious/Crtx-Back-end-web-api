using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrExtApiCore.Migrations
{
    public partial class changedRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackageRoles_PackageRolesId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_PackageRoles_PackageRolesId",
                table: "AspNetRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_Packages_packageId",
                table: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PackageRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_PackageRolesId",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_packageId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "PackageRolesId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "packageId",
                table: "AspNetRoles");

            migrationBuilder.RenameColumn(
                name: "PackageRolesId",
                table: "Packages",
                newName: "PackagesRolesId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_PackageRolesId",
                table: "Packages",
                newName: "IX_Packages_PackagesRolesId");

            migrationBuilder.AddColumn<int>(
                name: "PackageRoleId",
                table: "Packages",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PackagesRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PackageId = table.Column<int>(nullable: false),
                    PackageRoleId = table.Column<string>(nullable: true),
                    PackagesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagesRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackagesRoles_Packages_PackagesId",
                        column: x => x.PackagesId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PackageRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    PackageIdId = table.Column<int>(nullable: true),
                    PackagesRolesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageRole_Packages_PackageIdId",
                        column: x => x.PackageIdId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PackageRole_PackagesRoles_PackagesRolesId",
                        column: x => x.PackagesRolesId,
                        principalTable: "PackagesRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_PackageRoleId",
                table: "Packages",
                column: "PackageRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageRole_PackageIdId",
                table: "PackageRole",
                column: "PackageIdId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageRole_PackagesRolesId",
                table: "PackageRole",
                column: "PackagesRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagesRoles_PackagesId",
                table: "PackagesRoles",
                column: "PackagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_PackageRole_PackageRoleId",
                table: "Packages",
                column: "PackageRoleId",
                principalTable: "PackageRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Packages_PackageRole_PackageRoleId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackagesRoles_PackagesRolesId",
                table: "Packages");

            migrationBuilder.DropTable(
                name: "PackageRole");

            migrationBuilder.DropTable(
                name: "PackagesRoles");

            migrationBuilder.DropIndex(
                name: "IX_Packages_PackageRoleId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "PackageRoleId",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "PackagesRolesId",
                table: "Packages",
                newName: "PackageRolesId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_PackagesRolesId",
                table: "Packages",
                newName: "IX_Packages_PackageRolesId");

            migrationBuilder.AddColumn<int>(
                name: "PackageRolesId",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "packageId",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PackageRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PackageId = table.Column<int>(nullable: false),
                    RoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageRoles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_PackageRolesId",
                table: "AspNetRoles",
                column: "PackageRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_packageId",
                table: "AspNetRoles",
                column: "packageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_PackageRoles_PackageRolesId",
                table: "Packages",
                column: "PackageRolesId",
                principalTable: "PackageRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_PackageRoles_PackageRolesId",
                table: "AspNetRoles",
                column: "PackageRolesId",
                principalTable: "PackageRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_Packages_packageId",
                table: "AspNetRoles",
                column: "packageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
