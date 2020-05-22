using Microsoft.EntityFrameworkCore.Migrations;

namespace rflap_metrics.Migrations.TestResult
{
    public partial class CreateTestResultContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestResult",
                columns: table => new
                {
                    dataID = table.Column<string>(nullable: false),
                    sessionID = table.Column<string>(nullable: true),
                    testID = table.Column<string>(nullable: true),
                    callbackTime = table.Column<string>(nullable: true),
                    callbackPacket = table.Column<string>(nullable: true),
                    callbackHint = table.Column<string>(nullable: true),
                    testStringsCorrect = table.Column<string>(nullable: true),
                    numCorrect = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResult", x => x.dataID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestResult");
        }
    }
}
