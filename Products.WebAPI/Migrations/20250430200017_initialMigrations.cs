using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Products.API.Migrations
{
    /// <inheritdoc />
    public partial class initialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductSeller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    SellerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Sku = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSeller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSeller_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSeller_Seller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Seller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "42'' TV", "TV" },
                    { 2, "8KG fridge", "Fridge" },
                    { 3, "Xiaomi", "Smartphone" },
                    { 4, "Iphone", "Smartphone" }
                });

            migrationBuilder.InsertData(
                table: "Seller",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tech store" },
                    { 2, "House store" },
                    { 3, "Big Market" }
                });

            migrationBuilder.InsertData(
                table: "ProductSeller",
                columns: new[] { "Id", "Price", "ProductId", "SellerId", "Sku", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1599.00m, 1, 1, "152c048a-8f53-45fb-b080-891bf012d9b7", 10 },
                    { 2, 3499.00m, 1, 2, "32ea5a56-e466-455c-97f3-4847aac56aa5", 5 },
                    { 3, 3999.00m, 1, 1, "bb216151-4fba-4fb2-b99e-d7c2f2b43646", 20 },
                    { 4, 3999.00m, 2, 3, "cbd9b9d2-2351-4c22-ab08-dd1d8548e0a0", 20 },
                    { 5, 3999.00m, 3, 2, "8509dea8-7067-4243-afb2-6135358a0487", 20 },
                    { 6, 3999.00m, 4, 3, "0d11bac6-be52-4046-8607-be9eba10d97c", 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSeller_ProductId",
                table: "ProductSeller",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSeller_SellerId",
                table: "ProductSeller",
                column: "SellerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSeller");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Seller");
        }
    }
}
