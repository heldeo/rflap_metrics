using Microsoft.EntityFrameworkCore.Migrations;

namespace rflap_metrics.Migrations.TestResult
{
    public partial class TestResultUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TestResult",
                table: "TestResult");

            migrationBuilder.DropColumn(
                name: "dataID",
                table: "TestResult");

            migrationBuilder.AddColumn<int>(
                name: "baseID",
                table: "TestResult",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestResult",
                table: "TestResult",
                column: "baseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TestResult",
                table: "TestResult");

            migrationBuilder.DropColumn(
                name: "baseID",
                table: "TestResult");

            migrationBuilder.AddColumn<string>(
                name: "dataID",
                table: "TestResult",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestResult",
                table: "TestResult",
                column: "dataID");
        }
    }
}
