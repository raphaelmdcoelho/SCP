﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SCP.Repository.Context;

namespace SCP.Repository.Migrations
{
    [DbContext(typeof(BaseContext))]
    [Migration("20210101225807_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SCP.Domain.Cargo.CargoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo")
                        .HasColumnName("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.ToTable("Cargo");
                });

            modelBuilder.Entity("SCP.Domain.Documento.DocumentoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DthExclusao")
                        .HasColumnName("DthExclusao")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("DthRegistro")
                        .IsRequired()
                        .HasColumnName("DthRegistro")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("IsAtivo")
                        .IsRequired()
                        .HasColumnName("CEP")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<int>("MidiaId")
                        .HasColumnName("MidiaId")
                        .HasColumnType("int");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnName("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MidiaId")
                        .IsUnique();

                    b.HasIndex("PessoaId");

                    b.ToTable("Documento");
                });

            modelBuilder.Entity("SCP.Domain.Localizacao.Cidade.CidadeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo")
                        .HasColumnName("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Latitude")
                        .HasColumnName("Latitude")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Longitude")
                        .HasColumnName("Longitude")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("SCP.Domain.Localizacao.Endereco.EnderecoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnName("CEP")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<int>("CidadeId")
                        .HasColumnName("CidadeId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoId")
                        .HasColumnName("EstadoId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCorrespondencia")
                        .HasColumnName("IsCorrespondencia")
                        .HasColumnType("bit");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnName("Logradouro")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("NumeroPorta")
                        .HasColumnName("NumeroPorta")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("EstadoId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("SCP.Domain.Localizacao.Estado.EstadoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo")
                        .HasColumnName("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnName("Sigla")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("SCP.Domain.Midia.MidiaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnName("Conteudo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extensao")
                        .HasColumnName("Extensao")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Midia");
                });

            modelBuilder.Entity("SCP.Domain.Pessoa.PessoaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DthCriacao")
                        .HasColumnName("DthCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DthExclusao")
                        .HasColumnName("DthExclusao")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAtivo")
                        .HasColumnName("IsAtivo")
                        .HasColumnType("bit");

                    b.Property<int>("Tipo")
                        .HasColumnName("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("SCP.Domain.PessoaFisica.PessoaFisicaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Altura")
                        .HasColumnName("Altura")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnName("CPF")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<DateTime>("DthNascimento")
                        .HasColumnName("DthNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnName("Genero")
                        .HasColumnType("nvarchar(1)")
                        .HasMaxLength(1);

                    b.Property<string>("Peso")
                        .HasColumnName("Peso")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<int>("PessoaId")
                        .HasColumnName("PessoaId")
                        .HasColumnType("int");

                    b.Property<string>("PrimeiroNome")
                        .IsRequired()
                        .HasColumnName("PrimeiroNome")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("RG")
                        .HasColumnName("RG")
                        .HasColumnType("nvarchar(1)")
                        .HasMaxLength(1);

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnName("Sobrenome")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("PessoaFisica");
                });

            modelBuilder.Entity("SCP.Domain.PessoaJuridica.PessoaJuridicaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnName("CNPJ")
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnName("NomeFantasia")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<int>("PessoaId")
                        .HasColumnName("PessoaId")
                        .HasColumnType("int");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnName("RazaoSocial")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("PessoaJuridica");
                });

            modelBuilder.Entity("SCP.Domain.PessoaVinculo.PessoaVinculoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DthExclusao")
                        .HasColumnName("DthExclusao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DthRegistro")
                        .HasColumnName("DthRegistro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAtivo")
                        .HasColumnName("IsAtivo")
                        .HasColumnType("bit");

                    b.Property<int>("PessoaFisicaId")
                        .HasColumnName("PessoaFisicaId")
                        .HasColumnType("int");

                    b.Property<int>("PessoaJuridicaId")
                        .HasColumnName("PessoaJuridicaId")
                        .HasColumnType("int");

                    b.Property<int>("TipoVinculo")
                        .HasColumnName("TipoVinculo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PessoaFisicaId");

                    b.HasIndex("PessoaJuridicaId");

                    b.ToTable("PessoaVinculo");
                });

            modelBuilder.Entity("SCP.Domain.Profissao.ProfissaoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo")
                        .HasColumnName("Codigo")
                        .HasColumnType("int")
                        .HasMaxLength(5);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.ToTable("Profissao");
                });

            modelBuilder.Entity("SCP.Domain.ProfissaoVinculo.ProfissaoVinculoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CargoId")
                        .HasColumnName("CargoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DthDesligamento")
                        .HasColumnName("DthDesligamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DthExclusao")
                        .HasColumnName("DthExclusao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DthInicio")
                        .HasColumnName("DthInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("PessoaFisicaId")
                        .HasColumnName("PessoaFisicaId")
                        .HasColumnType("int");

                    b.Property<int>("ProfissaoId")
                        .HasColumnName("ProfissaoId")
                        .HasColumnType("int");

                    b.Property<string>("Salario")
                        .IsRequired()
                        .HasColumnName("Salario")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.HasIndex("PessoaFisicaId");

                    b.HasIndex("ProfissaoId");

                    b.ToTable("ProfissaoVinculo");
                });

            modelBuilder.Entity("SCP.Domain.Documento.DocumentoEntity", b =>
                {
                    b.HasOne("SCP.Domain.Midia.MidiaEntity", "Midia")
                        .WithOne("Documento")
                        .HasForeignKey("SCP.Domain.Documento.DocumentoEntity", "MidiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SCP.Domain.Pessoa.PessoaEntity", "Pessoa")
                        .WithMany("Documentos")
                        .HasForeignKey("PessoaId")
                        .HasConstraintName("documento_pessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SCP.Domain.Localizacao.Endereco.EnderecoEntity", b =>
                {
                    b.HasOne("SCP.Domain.Localizacao.Cidade.CidadeEntity", "Cidade")
                        .WithMany("Enderecos")
                        .HasForeignKey("CidadeId")
                        .HasConstraintName("endereco_cidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SCP.Domain.Localizacao.Estado.EstadoEntity", "Estado")
                        .WithMany("Enderecos")
                        .HasForeignKey("EstadoId")
                        .HasConstraintName("endereco_estado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SCP.Domain.Pessoa.PessoaEntity", "Pessoa")
                        .WithMany("Enderecos")
                        .HasForeignKey("EstadoId")
                        .HasConstraintName("endereco_pessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SCP.Domain.PessoaFisica.PessoaFisicaEntity", b =>
                {
                    b.HasOne("SCP.Domain.Pessoa.PessoaEntity", "Pessoa")
                        .WithOne("PessoaFisica")
                        .HasForeignKey("SCP.Domain.PessoaFisica.PessoaFisicaEntity", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SCP.Domain.PessoaJuridica.PessoaJuridicaEntity", b =>
                {
                    b.HasOne("SCP.Domain.Pessoa.PessoaEntity", "Pessoa")
                        .WithOne("PessoaJuridica")
                        .HasForeignKey("SCP.Domain.PessoaJuridica.PessoaJuridicaEntity", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SCP.Domain.PessoaVinculo.PessoaVinculoEntity", b =>
                {
                    b.HasOne("SCP.Domain.PessoaFisica.PessoaFisicaEntity", "PessoaFisica")
                        .WithMany("EmpresasVinculadas")
                        .HasForeignKey("PessoaFisicaId")
                        .HasConstraintName("pessoa_vinculo_pessoa_fisica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SCP.Domain.PessoaJuridica.PessoaJuridicaEntity", "PessoaJuridica")
                        .WithMany("Socios")
                        .HasForeignKey("PessoaJuridicaId")
                        .HasConstraintName("documento_vinculo_pessoa_juridica")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SCP.Domain.ProfissaoVinculo.ProfissaoVinculoEntity", b =>
                {
                    b.HasOne("SCP.Domain.Cargo.CargoEntity", "Cargo")
                        .WithMany("ProfissoesVinculos")
                        .HasForeignKey("CargoId")
                        .HasConstraintName("profissao_vinculo_cargo");

                    b.HasOne("SCP.Domain.PessoaFisica.PessoaFisicaEntity", "PessoaFisica")
                        .WithMany("Profissoes")
                        .HasForeignKey("PessoaFisicaId")
                        .HasConstraintName("profissao_vinculo_pessoa_fisica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SCP.Domain.Profissao.ProfissaoEntity", "Profissao")
                        .WithMany("ProfissoesVinculos")
                        .HasForeignKey("ProfissaoId")
                        .HasConstraintName("profissao_vinculo_profissao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
