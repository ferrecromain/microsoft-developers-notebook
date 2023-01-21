using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoyaltyCardManager.Infrastructure.Data.Migrations
{
    public partial class AddedUserandGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoyaltyCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MerchantName = table.Column<string>(type: "TEXT", nullable: true),
                    MembershipId = table.Column<string>(type: "TEXT", nullable: true),
                    GroupId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoyaltyCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoyaltyCard_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Fast Food and casual Dining", "Restaurants" });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Airlines, railways companies", "Transports" });

            migrationBuilder.InsertData(
                table: "LoyaltyCard",
                columns: new[] { "Id", "GroupId", "MembershipId", "MerchantName" },
                values: new object[] { 1, 1, "0035595443", "Los pollos hermanos" });

            migrationBuilder.InsertData(
                table: "LoyaltyCard",
                columns: new[] { "Id", "GroupId", "MembershipId", "MerchantName" },
                values: new object[] { 2, 1, "2178445", "Big Kahuna burger" });

            migrationBuilder.InsertData(
                table: "LoyaltyCard",
                columns: new[] { "Id", "GroupId", "MembershipId", "MerchantName" },
                values: new object[] { 3, 2, "6259663200", "Oceanic Airlines" });

            migrationBuilder.CreateIndex(
                name: "IX_LoyaltyCard_GroupId",
                table: "LoyaltyCard",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoyaltyCard");

            migrationBuilder.DropTable(
                name: "Group");
        }
    }
}
