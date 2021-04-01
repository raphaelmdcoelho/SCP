using Microsoft.EntityFrameworkCore.Migrations;

namespace SCP.Repository.Migrations
{
    public partial class correcaoEnderecoPessoaIdFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "endereco_pessoa",
                table: "Endereco");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_PessoaId",
                table: "Endereco",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "endereco_pessoa",
                table: "Endereco",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "endereco_pessoa",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_PessoaId",
                table: "Endereco");

            migrationBuilder.AddForeignKey(
                name: "endereco_pessoa",
                table: "Endereco",
                column: "EstadoId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
