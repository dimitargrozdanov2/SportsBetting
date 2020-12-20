using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsBetting.Data.Migrations
{
    public partial class OddsAreDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "OddsForSecondTeam",
                table: "Events",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "OddsForFirstTeam",
                table: "Events",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "OddsForDraw",
                table: "Events",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "OddsForSecondTeam",
                table: "Events",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "OddsForFirstTeam",
                table: "Events",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "OddsForDraw",
                table: "Events",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
