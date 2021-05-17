using Microsoft.EntityFrameworkCore.Migrations;

namespace Course.Migrations
{
    public partial class fixrosteritem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "RosterItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "price",
                table: "RosterItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
