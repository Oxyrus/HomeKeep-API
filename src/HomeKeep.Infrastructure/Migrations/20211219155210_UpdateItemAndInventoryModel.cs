using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeKeep.Infrastructure.Migrations
{
    public partial class UpdateItemAndInventoryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Purchased",
                table: "Item",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Purchased",
                table: "Item");
        }
    }
}
