using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SCP.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Codigo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 150, nullable: false),
                    Longitude = table.Column<string>(maxLength: 10, nullable: true),
                    Latitude = table.Column<string>(maxLength: 10, nullable: true),
                    Codigo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 150, nullable: false),
                    Sigla = table.Column<string>(maxLength: 2, nullable: false),
                    Codigo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Midia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Conteudo = table.Column<string>(nullable: false),
                    Extensao = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Midia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(nullable: false),
                    IsAtivo = table.Column<bool>(nullable: false),
                    DthCriacao = table.Column<DateTime>(nullable: false),
                    DthExclusao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profissao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Codigo = table.Column<int>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MidiaId = table.Column<int>(nullable: false),
                    PessoaId = table.Column<int>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    DthRegistro = table.Column<string>(maxLength: 500, nullable: false),
                    DthExclusao = table.Column<string>(maxLength: 10, nullable: true),
                    CEP = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documento_Midia_MidiaId",
                        column: x => x.MidiaId,
                        principalTable: "Midia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "documento_pessoa",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoId = table.Column<int>(nullable: false),
                    CidadeId = table.Column<int>(nullable: false),
                    PessoaId = table.Column<int>(nullable: false),
                    IsCorrespondencia = table.Column<bool>(nullable: false),
                    Logradouro = table.Column<string>(maxLength: 500, nullable: false),
                    NumeroPorta = table.Column<string>(maxLength: 10, nullable: true),
                    CEP = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "endereco_cidade",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "endereco_estado",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "endereco_pessoa",
                        column: x => x.EstadoId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PessoaFisica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(nullable: false),
                    PrimeiroNome = table.Column<string>(maxLength: 100, nullable: false),
                    Sobrenome = table.Column<string>(maxLength: 200, nullable: false),
                    DthNascimento = table.Column<DateTime>(nullable: false),
                    Genero = table.Column<string>(maxLength: 1, nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    RG = table.Column<string>(maxLength: 1, nullable: true),
                    Altura = table.Column<string>(maxLength: 3, nullable: true),
                    Peso = table.Column<string>(maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFisica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaFisica_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PessoaJuridica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(nullable: false),
                    RazaoSocial = table.Column<string>(maxLength: 300, nullable: false),
                    NomeFantasia = table.Column<string>(maxLength: 300, nullable: false),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaJuridica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaJuridica_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfissaoVinculo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaFisicaId = table.Column<int>(nullable: false),
                    ProfissaoId = table.Column<int>(nullable: false),
                    CargoId = table.Column<int>(nullable: true),
                    Salario = table.Column<string>(maxLength: 15, nullable: false),
                    DthInicio = table.Column<DateTime>(nullable: false),
                    DthDesligamento = table.Column<DateTime>(nullable: true),
                    DthExclusao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfissaoVinculo", x => x.Id);
                    table.ForeignKey(
                        name: "profissao_vinculo_cargo",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "profissao_vinculo_pessoa_fisica",
                        column: x => x.PessoaFisicaId,
                        principalTable: "PessoaFisica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "profissao_vinculo_profissao",
                        column: x => x.ProfissaoId,
                        principalTable: "Profissao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PessoaVinculo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaFisicaId = table.Column<int>(nullable: false),
                    PessoaJuridicaId = table.Column<int>(nullable: false),
                    TipoVinculo = table.Column<int>(nullable: false),
                    DthRegistro = table.Column<DateTime>(nullable: false),
                    DthExclusao = table.Column<DateTime>(nullable: false),
                    IsAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaVinculo", x => x.Id);
                    table.ForeignKey(
                        name: "pessoa_vinculo_pessoa_fisica",
                        column: x => x.PessoaFisicaId,
                        principalTable: "PessoaFisica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "documento_vinculo_pessoa_juridica",
                        column: x => x.PessoaJuridicaId,
                        principalTable: "PessoaJuridica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_Codigo",
                table: "Cargo",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documento_MidiaId",
                table: "Documento",
                column: "MidiaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documento_PessoaId",
                table: "Documento",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_CidadeId",
                table: "Endereco",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_EstadoId",
                table: "Endereco",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaFisica_PessoaId",
                table: "PessoaFisica",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PessoaJuridica_PessoaId",
                table: "PessoaJuridica",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PessoaVinculo_PessoaFisicaId",
                table: "PessoaVinculo",
                column: "PessoaFisicaId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaVinculo_PessoaJuridicaId",
                table: "PessoaVinculo",
                column: "PessoaJuridicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Profissao_Codigo",
                table: "Profissao",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfissaoVinculo_CargoId",
                table: "ProfissaoVinculo",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfissaoVinculo_PessoaFisicaId",
                table: "ProfissaoVinculo",
                column: "PessoaFisicaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfissaoVinculo_ProfissaoId",
                table: "ProfissaoVinculo",
                column: "ProfissaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documento");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "PessoaVinculo");

            migrationBuilder.DropTable(
                name: "ProfissaoVinculo");

            migrationBuilder.DropTable(
                name: "Midia");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "PessoaJuridica");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "PessoaFisica");

            migrationBuilder.DropTable(
                name: "Profissao");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
