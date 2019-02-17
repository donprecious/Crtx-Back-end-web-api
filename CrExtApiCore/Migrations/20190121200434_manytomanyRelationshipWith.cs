using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrExtApiCore.Migrations
{
    public partial class manytomanyRelationshipWith : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackageRoles_PackageRoleId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackagesRoles_PackagesRolesId",
                table: "Packages");

            migrationBuilder.DropTable(
                name: "PackageRoles");

            migrationBuilder.DropTable(
                name: "PackagesRoles");

            migrationBuilder.DropIndex(
                name: "IX_Packages_PackageRoleId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_PackagesRolesId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "PackageRoleId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "PackagesRolesId",
                table: "Packages");

            migrationBuilder.CreateTable(
                name: "PRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackagePRoles",
                columns: table => new
                {
                    PackageId = table.Column<int>(nullable: false),
                    PRoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagePRoles", x => new { x.PackageId, x.PRoleId });
                    table.ForeignKey(
                        name: "FK_PackagePRoles_PRoles_PRoleId",
                        column: x => x.PRoleId,
                        principalTable: "PRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackagePRoles_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackagePRoles_PRoleId",
                table: "PackagePRoles",
                column: "PRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackagePRoles");

            migrationBuilder.DropTable(
                name: "PRoles");

            migrationBuilder.AddColumn<int>(
                name: "PackageRoleId",
                table: "Packages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PackagesRolesId",
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
                name: "PackageRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    PackageId = table.Column<int>(nullable: true),
                    PackagesRolesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageRoles_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PackageRoles_PackagesRoles_PackagesRolesId",
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
                name: "IX_Packages_PackagesRolesId",
                table: "Packages",
                column: "PackagesRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageRoles_PackageId",
                table: "PackageRoles",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageRoles_PackagesRolesId",
                table: "PackageRoles",
                column: "PackagesRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagesRoles_PackagesId",
                table: "PackagesRoles",
                column: "PackagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_PackageRoles_PackageRoleId",
                table: "Packages",
                column: "PackageRoleId",
                principalTable: "PackageRoles",
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
    }
}
