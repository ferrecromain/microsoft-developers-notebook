using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetSampleSolution.Infrastructure.Data.Migrations
{
    public partial class AddedUserandGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Birthday = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Formats the information provided by a website or an application through a set of contents", "Design team" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Responsible for all the work required to create functional and quality software.", "Development team" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "Works to promote products and services on the Internet", "SEO & marketing" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 4, "Accountable for the sound financial, accounting, and budgetary management of the programs, and the management of human resources and administrative / legal records", "Finance/HR/Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(1989, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.wilson@company.tld", "Michael", "Wilson" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "FirstName", "LastName" },
                values: new object[] { 2, new DateTime(1979, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "jerry.whitehall@company.tld", "Jerry", "Whitehall" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "FirstName", "LastName" },
                values: new object[] { 3, new DateTime(1984, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "peter.parvin@company.tld", "Peter", "Parvin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "FirstName", "LastName" },
                values: new object[] { 4, new DateTime(1989, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "mary.reed@company.tld", "Mary", "Reed" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "FirstName", "LastName" },
                values: new object[] { 5, new DateTime(1990, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "lucy.estevez@company.tld", "Ducy", "Estevez" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "FirstName", "LastName" },
                values: new object[] { 6, new DateTime(1985, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "donna.archer@company.tld", "Donna", "Archer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
