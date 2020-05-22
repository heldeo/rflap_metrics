using Microsoft.EntityFrameworkCore.Migrations;

namespace rflap_metrics.Migrations.Export
{
    public partial class CreateExportContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Export",
                columns: table => new
                {
                    dataID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sessionID = table.Column<string>(nullable: true),
                    exportTime = table.Column<string>(nullable: true),
                    downloadPacket = table.Column<string>(nullable: true),
                    mode = table.Column<string>(nullable: true),
                    initialState = table.Column<string>(nullable: true),
                    numStates = table.Column<int>(nullable: false),
                    numAccepting = table.Column<int>(nullable: false),
                    numTransitions = table.Column<int>(nullable: false),
                    testID = table.Column<string>(nullable: true),
                    exportID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Export", x => x.dataID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Export");
        }
    }
}
