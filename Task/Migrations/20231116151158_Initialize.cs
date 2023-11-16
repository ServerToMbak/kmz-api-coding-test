using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Envanters",
                newName: "quantity");

            migrationBuilder.AddColumn<string>(
                name: "BrandName",
                table: "Envanters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Envanters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    EnvanterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Envanters_EnvanterId",
                        column: x => x.EnvanterId,
                        principalTable: "Envanters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Envanters_CategoryId",
                table: "Envanters",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_EnvanterId",
                table: "Products",
                column: "EnvanterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Envanters_Categories_CategoryId",
                table: "Envanters",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envanters_Categories_CategoryId",
                table: "Envanters");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Envanters_CategoryId",
                table: "Envanters");

            migrationBuilder.DropColumn(
                name: "BrandName",
                table: "Envanters");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Envanters");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Envanters",
                newName: "Quantity");
        }
    }
}
