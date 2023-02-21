using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VendingMachine.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ProductType = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "Name", "Price", "ProductType" },
                values: new object[,]
                {
                    { 1, (byte)10, "Potion Strength", 200, 1 },
                    { 2, (byte)10, "Potion Agility", 100, 2 },
                    { 3, (byte)10, "Potion Intelligence", 150, 3 },
                    { 4, (byte)10, "Potion Invisibility", 300, 4 },
                    { 5, (byte)10, "Potion Invulnerability", 200, 5 },
                    { 6, (byte)10, "Potion Health", 150, 0 },
                    { 7, (byte)10, "Potion PotionType1", 150, 7 },
                    { 8, (byte)10, "Potion PotionType2", 200, 8 },
                    { 9, (byte)10, "Potion PotionType3", 300, 9 },
                    { 10, (byte)10, "Potion Random", 500, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
