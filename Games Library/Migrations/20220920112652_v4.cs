using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Games_Library.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DirectX",
                table: "SysReqs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DirectX",
                table: "SysReqs");
        }
    }
}
