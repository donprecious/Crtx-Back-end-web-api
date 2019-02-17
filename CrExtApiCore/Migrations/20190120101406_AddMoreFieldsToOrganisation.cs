using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrExtApiCore.Migrations
{
    public partial class AddMoreFieldsToOrganisation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BusinessAddress",
                table: "Organisations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nature_of_Business",
                table: "Organisations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Organisations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RC_Number",
                table: "Organisations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessAddress",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "Nature_of_Business",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "RC_Number",
                table: "Organisations");
        }
    }
}
