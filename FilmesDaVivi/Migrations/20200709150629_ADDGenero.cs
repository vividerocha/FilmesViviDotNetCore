using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmesDaVivi.Migrations
{
    public partial class ADDGenero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Filmes",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Filmes");
        }
    }
}
