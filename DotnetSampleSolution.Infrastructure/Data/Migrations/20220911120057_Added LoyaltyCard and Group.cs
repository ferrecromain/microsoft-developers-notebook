using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetSampleSolution.Infrastructure.Data.Migrations
{
    public partial class AddedLoyaltyCardandGroup : Migration
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
                name: "loyaltyCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MerchantName = table.Column<string>(type: "TEXT", nullable: true),
                    MembershipId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loyaltyCards", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Fast Food and casual Dining", "Restaurants" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Airlines, railways companies", "Transports" });

            migrationBuilder.InsertData(
                table: "loyaltyCards",
                columns: new[] { "Id", "MembershipId", "MerchantName" },
                values: new object[] { 1, "0035595443", "Los pollos hermanos" });

            migrationBuilder.InsertData(
                table: "loyaltyCards",
                columns: new[] { "Id", "MembershipId", "MerchantName" },
                values: new object[] { 2, "2178445", "Big Kahuna burger" });

            migrationBuilder.InsertData(
                table: "loyaltyCards",
                columns: new[] { "Id", "MembershipId", "MerchantName" },
                values: new object[] { 3, "6259663200", "Oceanic Airlines" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "loyaltyCards");
        }
    }
}
