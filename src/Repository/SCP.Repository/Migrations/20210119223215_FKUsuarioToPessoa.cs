using Microsoft.EntityFrameworkCore.Migrations;

namespace SCP.Repository.Migrations
{
    public partial class FKUsuarioToPessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Pessoa",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_UsuarioId",
                table: "Pessoa",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "pessoa_usuario",
                table: "Pessoa",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "pessoa_usuario",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_UsuarioId",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Pessoa");
        }
    }
}
