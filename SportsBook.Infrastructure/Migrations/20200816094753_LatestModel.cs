using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsBook.Infrastructure.Migrations
{
    public partial class LatestModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "Selection",
                newName: "SelectionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "Market",
                newName: "MarketId");

            migrationBuilder.AlterColumn<string>(
                name: "Outcome",
                schema: "dbo",
                table: "Selection",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "dbo",
                table: "Market",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "dbo",
                table: "Event",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EventType",
                schema: "dbo",
                table: "Event",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                schema: "dbo",
                table: "Market");

            migrationBuilder.RenameColumn(
                name: "SelectionId",
                schema: "dbo",
                table: "Selection",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MarketId",
                schema: "dbo",
                table: "Market",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Outcome",
                schema: "dbo",
                table: "Selection",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "dbo",
                table: "Event",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "EventType",
                schema: "dbo",
                table: "Event",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
