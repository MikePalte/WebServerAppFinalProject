using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerPlaces.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    BarId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drinks_Bars_BarId",
                        column: x => x.BarId,
                        principalTable: "Bars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drinks_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bars",
                columns: new[] { "Id", "Address", "Name", "State", "Zip" },
                values: new object[,]
                {
                    { 1, "Calhoun Street, Cincinati", "Uncle Woodys", "OH", "45219" },
                    { 2, "West Mcmillian, Cincinnati", "Macs", "OH", "45219" },
                    { 3, "Vine St, Cincinnati", "Top Cats", "OH", "45219" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Beer" },
                    { 2, "Wine" },
                    { 3, "Whiskey" },
                    { 4, "Seltzer" }
                });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "BarId", "CategoryId", "Name", "Price" },
                values: new object[] { 1, 1, 1, "Keystone", 0m });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "BarId", "CategoryId", "Name", "Price" },
                values: new object[] { 2, 2, 2, "Cinci Red Wine", 0m });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "BarId", "CategoryId", "Name", "Price" },
                values: new object[] { 3, 3, 3, "Cinci Whiskey", 0m });

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_BarId",
                table: "Drinks",
                column: "BarId");

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_CategoryId",
                table: "Drinks",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Bars");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
