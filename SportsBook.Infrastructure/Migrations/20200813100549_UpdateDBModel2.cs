using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsBook.Infrastructure.Migrations
{
    public partial class UpdateDBModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Selection_Event_EventId",
                schema: "dbo",
                table: "Selection");

            migrationBuilder.DropForeignKey(
                name: "FK_Selection_Market_MarketId",
                schema: "dbo",
                table: "Selection");

            migrationBuilder.AddForeignKey(
                name: "FK_Selection_Event_EventId",
                schema: "dbo",
                table: "Selection",
                column: "EventId",
                principalSchema: "dbo",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Selection_Market_MarketId",
                schema: "dbo",
                table: "Selection",
                column: "MarketId",
                principalSchema: "dbo",
                principalTable: "Market",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Selection_Event_EventId",
                schema: "dbo",
                table: "Selection");

            migrationBuilder.DropForeignKey(
                name: "FK_Selection_Market_MarketId",
                schema: "dbo",
                table: "Selection");

            migrationBuilder.AddForeignKey(
                name: "FK_Selection_Event_EventId",
                schema: "dbo",
                table: "Selection",
                column: "EventId",
                principalSchema: "dbo",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Selection_Market_MarketId",
                schema: "dbo",
                table: "Selection",
                column: "MarketId",
                principalSchema: "dbo",
                principalTable: "Market",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
