using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Games_Library.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SysReq_Games_GameId",
                table: "SysReq");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SysReq",
                table: "SysReq");

            migrationBuilder.RenameTable(
                name: "SysReq",
                newName: "SysReqs");

            migrationBuilder.RenameIndex(
                name: "IX_SysReq_GameId",
                table: "SysReqs",
                newName: "IX_SysReqs_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SysReqs",
                table: "SysReqs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SysReqs_Games_GameId",
                table: "SysReqs",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SysReqs_Games_GameId",
                table: "SysReqs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SysReqs",
                table: "SysReqs");

            migrationBuilder.RenameTable(
                name: "SysReqs",
                newName: "SysReq");

            migrationBuilder.RenameIndex(
                name: "IX_SysReqs_GameId",
                table: "SysReq",
                newName: "IX_SysReq_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SysReq",
                table: "SysReq",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SysReq_Games_GameId",
                table: "SysReq",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
