using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop.Migrations
{
    /// <inheritdoc />
    public partial class card3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "shopCartId",
                table: "ShopCartItem",
                newName: "ShopCartId");

            migrationBuilder.AlterColumn<string>(
                name: "ShopCartId",
                table: "ShopCartItem",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShopCartId",
                table: "ShopCartItem",
                newName: "shopCartId");

            migrationBuilder.AlterColumn<int>(
                name: "shopCartId",
                table: "ShopCartItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
