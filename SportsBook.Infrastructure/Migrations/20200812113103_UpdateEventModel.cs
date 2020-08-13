using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsBook.Infrastructure.Migrations
{
    public partial class UpdateEventModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "Event",
                newName: "EventId");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                schema: "dbo",
                table: "Market",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Market_EventId",
                schema: "dbo",
                table: "Market",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Market_Event_EventId",
                schema: "dbo",
                table: "Market",
                column: "EventId",
                principalSchema: "dbo",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Market_Event_EventId",
                schema: "dbo",
                table: "Market");

            migrationBuilder.DropIndex(
                name: "IX_Market_EventId",
                schema: "dbo",
                table: "Market");

            migrationBuilder.DropColumn(
                name: "EventId",
                schema: "dbo",
                table: "Market");

            migrationBuilder.RenameColumn(
                name: "EventId",
                schema: "dbo",
                table: "Event",
                newName: "Id");
        }
    }
}
