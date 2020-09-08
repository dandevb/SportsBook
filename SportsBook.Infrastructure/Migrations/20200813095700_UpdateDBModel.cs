using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsBook.Infrastructure.Migrations
{
    public partial class UpdateDBModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Id",
                schema: "dbo",
                table: "Sport",
                newName: "SportId");

            migrationBuilder.AlterColumn<string>(
                name: "Outcome",
                schema: "dbo",
                table: "Selection",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                schema: "dbo",
                table: "Selection",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MarketId",
                schema: "dbo",
                table: "Selection",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventForeignKey",
                schema: "dbo",
                table: "Market",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "dbo",
                table: "Event",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EventType",
                schema: "dbo",
                table: "Event",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "SportEvents",
                columns: table => new
                {
                    SportId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportEvents", x => new { x.SportId, x.EventId });
                    table.ForeignKey(
                        name: "FK_SportEvents_Event_EventId",
                        column: x => x.EventId,
                        principalSchema: "dbo",
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportEvents_Sport_SportId",
                        column: x => x.SportId,
                        principalSchema: "dbo",
                        principalTable: "Sport",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Selection_EventId",
                schema: "dbo",
                table: "Selection",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Selection_MarketId",
                schema: "dbo",
                table: "Selection",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_Market_EventForeignKey",
                schema: "dbo",
                table: "Market",
                column: "EventForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_SportEvents_EventId",
                table: "SportEvents",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Market_Event_EventForeignKey",
                schema: "dbo",
                table: "Market",
                column: "EventForeignKey",
                principalSchema: "dbo",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.NoAction);

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
                name: "FK_Market_Event_EventForeignKey",
                schema: "dbo",
                table: "Market");

            migrationBuilder.DropForeignKey(
                name: "FK_Selection_Event_EventId",
                schema: "dbo",
                table: "Selection");

            migrationBuilder.DropForeignKey(
                name: "FK_Selection_Market_MarketId",
                schema: "dbo",
                table: "Selection");

            migrationBuilder.DropTable(
                name: "SportEvents");

            migrationBuilder.DropIndex(
                name: "IX_Selection_EventId",
                schema: "dbo",
                table: "Selection");

            migrationBuilder.DropIndex(
                name: "IX_Selection_MarketId",
                schema: "dbo",
                table: "Selection");

            migrationBuilder.DropIndex(
                name: "IX_Market_EventForeignKey",
                schema: "dbo",
                table: "Market");

            migrationBuilder.DropColumn(
                name: "EventId",
                schema: "dbo",
                table: "Selection");

            migrationBuilder.DropColumn(
                name: "MarketId",
                schema: "dbo",
                table: "Selection");

            migrationBuilder.DropColumn(
                name: "EventForeignKey",
                schema: "dbo",
                table: "Market");

            migrationBuilder.RenameColumn(
                name: "SportId",
                schema: "dbo",
                table: "Sport",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Outcome",
                schema: "dbo",
                table: "Selection",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                schema: "dbo",
                table: "Market",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                schema: "dbo",
                table: "Event",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "EventType",
                schema: "dbo",
                table: "Event",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

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
    }
}
