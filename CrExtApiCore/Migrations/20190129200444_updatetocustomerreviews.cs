using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrExtApiCore.Migrations
{
    public partial class updatetocustomerreviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerFeedBacks");

            migrationBuilder.DropTable(
                name: "FeedBackTypes");

            migrationBuilder.CreateTable(
                name: "ReviewActions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReviewKinds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewKinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(maxLength: 1000, nullable: true),
                    CustomerId = table.Column<string>(nullable: true),
                    CustomerId1 = table.Column<Guid>(nullable: true),
                    TeamMemberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_TeamMembers_TeamMemberId",
                        column: x => x.TeamMemberId,
                        principalTable: "TeamMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ReviewActionId = table.Column<int>(nullable: false),
                    ReviewId = table.Column<int>(nullable: false),
                    ReviewKindId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewNotifications_ReviewActions_ReviewActionId",
                        column: x => x.ReviewActionId,
                        principalTable: "ReviewActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewNotifications_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewNotifications_ReviewKinds_ReviewKindId",
                        column: x => x.ReviewKindId,
                        principalTable: "ReviewKinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewNotifications_ReviewActionId",
                table: "ReviewNotifications",
                column: "ReviewActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewNotifications_ReviewId",
                table: "ReviewNotifications",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewNotifications_ReviewKindId",
                table: "ReviewNotifications",
                column: "ReviewKindId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CustomerId1",
                table: "Reviews",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TeamMemberId",
                table: "Reviews",
                column: "TeamMemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewNotifications");

            migrationBuilder.DropTable(
                name: "ReviewActions");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ReviewKinds");

            migrationBuilder.CreateTable(
                name: "FeedBackTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descriptions = table.Column<string>(maxLength: 400, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBackTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerFeedBacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    CustomerId = table.Column<string>(nullable: true),
                    CustomersId = table.Column<Guid>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateProcess = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    FeedBackTypeId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFeedBacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerFeedBacks_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerFeedBacks_FeedBackTypes_FeedBackTypeId",
                        column: x => x.FeedBackTypeId,
                        principalTable: "FeedBackTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeedBacks_CustomersId",
                table: "CustomerFeedBacks",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeedBacks_FeedBackTypeId",
                table: "CustomerFeedBacks",
                column: "FeedBackTypeId");
        }
    }
}
