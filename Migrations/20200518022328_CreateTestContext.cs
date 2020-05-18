using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rflap_metrics.Migrations
{
    public partial class CreateTestContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    dataID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sessionID = table.Column<string>(nullable: true),
                    startTime = table.Column<DateTime>(nullable: false),
                    testTime = table.Column<string>(nullable: true),
                    rustPacket = table.Column<string>(nullable: true),
                    mode = table.Column<string>(nullable: true),
                    initialState = table.Column<string>(nullable: true),
                    numStates = table.Column<int>(nullable: false),
                    numAccepting = table.Column<int>(nullable: false),
                    numTransitions = table.Column<int>(nullable: false),
                    testStrings = table.Column<string>(nullable: true),
                    testID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.dataID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test");
        }
    }
}
