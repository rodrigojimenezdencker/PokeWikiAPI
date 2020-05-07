using Microsoft.EntityFrameworkCore.Migrations;

namespace PokeWikiAPI.Migrations
{
    public partial class ChangedNullables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvolutionId",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "PrevolutionId",
                table: "Pokemon");

            migrationBuilder.AddColumn<int>(
                name: "Evolution",
                table: "Pokemon",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Prevolution",
                table: "Pokemon",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Power",
                table: "Move",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Accuracy",
                table: "Move",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Evolution",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "Prevolution",
                table: "Pokemon");

            migrationBuilder.AddColumn<int>(
                name: "EvolutionId",
                table: "Pokemon",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrevolutionId",
                table: "Pokemon",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Power",
                table: "Move",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Accuracy",
                table: "Move",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
