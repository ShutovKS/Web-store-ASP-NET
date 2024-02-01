using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_store.Migrations
{
    /// <inheritdoc />
    public partial class ItemInCartAddShopCartIdAndAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "ItemInCart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ShopCartId",
                table: "ItemInCart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ItemInCart");

            migrationBuilder.DropColumn(
                name: "ShopCartId",
                table: "ItemInCart");
        }
    }
}
