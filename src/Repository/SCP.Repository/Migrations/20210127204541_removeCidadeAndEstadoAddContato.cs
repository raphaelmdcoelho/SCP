using Microsoft.EntityFrameworkCore.Migrations;

namespace SCP.Repository.Migrations
{
    public partial class removeCidadeAndEstadoAddContato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "endereco_cidade",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "endereco_estado",
                table: "Endereco");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_CidadeId",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_EstadoId",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "CidadeId",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Endereco");

            migrationBuilder.RenameColumn(
                name: "CEP",
                table: "Endereco",
                newName: "Cep");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Endereco",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Endereco",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Endereco",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContatoEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(nullable: false),
                    DDD = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatoEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContatoEntity_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContatoEntity_PessoaId",
                table: "ContatoEntity",
                column: "PessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContatoEntity");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Endereco");

            migrationBuilder.RenameColumn(
                name: "Cep",
                table: "Endereco",
                newName: "CEP");

            migrationBuilder.AddColumn<int>(
                name: "CidadeId",
                table: "Endereco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Endereco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_CidadeId",
                table: "Endereco",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_EstadoId",
                table: "Endereco",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "endereco_cidade",
                table: "Endereco",
                column: "CidadeId",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "endereco_estado",
                table: "Endereco",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
