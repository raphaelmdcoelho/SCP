using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SCP.Repository.Migrations
{
    public partial class documentoDthChangeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContatoEntity_Pessoa_PessoaId",
                table: "ContatoEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContatoEntity",
                table: "ContatoEntity");

            migrationBuilder.RenameTable(
                name: "ContatoEntity",
                newName: "Contato");

            migrationBuilder.RenameIndex(
                name: "IX_ContatoEntity_PessoaId",
                table: "Contato",
                newName: "IX_Contato_PessoaId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DthRegistro",
                table: "Documento",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DthExclusao",
                table: "Documento",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Contato",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DDD",
                table: "Contato",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contato",
                table: "Contato",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "contato_pessoa",
                table: "Contato",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "contato_pessoa",
                table: "Contato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contato",
                table: "Contato");

            migrationBuilder.RenameTable(
                name: "Contato",
                newName: "ContatoEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Contato_PessoaId",
                table: "ContatoEntity",
                newName: "IX_ContatoEntity_PessoaId");

            migrationBuilder.AlterColumn<string>(
                name: "DthRegistro",
                table: "Documento",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "DthExclusao",
                table: "Documento",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "ContatoEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "DDD",
                table: "ContatoEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContatoEntity",
                table: "ContatoEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContatoEntity_Pessoa_PessoaId",
                table: "ContatoEntity",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
