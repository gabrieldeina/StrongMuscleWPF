using Microsoft.EntityFrameworkCore.Migrations;

namespace StrongMuscle.Migrations
{
    public partial class CorrecaoTreino2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Treinos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Treinos");
        }
    }
}
