using Microsoft.EntityFrameworkCore;
using SCP.Domain.Cargo;
using SCP.Domain.Contato;
using SCP.Domain.Documento;
using SCP.Domain.Historico;
using SCP.Domain.Localizacao.Endereco;
using SCP.Domain.Midia;
using SCP.Domain.Pessoa;
using SCP.Domain.PessoaFisica;
using SCP.Domain.PessoaJuridica;
using SCP.Domain.PessoaVinculo;
using SCP.Domain.Profissao;
using SCP.Domain.ProfissaoVinculo;
using SCP.Domain.Usuario;
using SCP.Repository.Configuration;

namespace SCP.Repository.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options)
            : base(options)
        {
        }

        public DbSet<ContatoEntity> Contatos { get; set; }
        public DbSet<EnderecoEntity> Enderecos { get; set; }
        public DbSet<PessoaEntity> Pessoas { get; set; }
        public DbSet<DocumentoEntity> Documentos { get; set; }
        public DbSet<MidiaEntity> Midias { get; set; }
        public DbSet<PessoaFisicaEntity> PessoasFisicas { get; set; }
        public DbSet<ProfissaoEntity> Profissoes { get; set; }
        public DbSet<CargoEntity> Cargos { get; set; }
        public DbSet<ProfissaoVinculoEntity> ProfissoesVinculos { get; set; }
        public DbSet<PessoaJuridicaEntity> PessoasJuridicas { get; set; }
        public DbSet<PessoaVinculoEntity> PessoasVinculos { get; set; }

        // Autenticação:
        public DbSet<UsuarioEntity> Usuarios { get; set; }

        // Hístórico:
        public DbSet<HistoricoEntity> Historicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ContatoTypeConfiguration().Configure(modelBuilder.Entity<ContatoEntity>());
            new EnderecoTypeConfiguration().Configure(modelBuilder.Entity<EnderecoEntity>());
            new PessoaTypeConfiguration().Configure(modelBuilder.Entity<PessoaEntity>());
            new DocumentoTypeConfiguration().Configure(modelBuilder.Entity<DocumentoEntity>());
            new MidiaTypeConfiguration().Configure(modelBuilder.Entity<MidiaEntity>());
            new PessoaFisicaTypeConfiguration().Configure(modelBuilder.Entity<PessoaFisicaEntity>());
            new ProfissaoTypeConfiguration().Configure(modelBuilder.Entity<ProfissaoEntity>());
            new PessoaJuridicaTypeConfiguration().Configure(modelBuilder.Entity<PessoaJuridicaEntity>());
            new PessoaVinculoTypeConfiguration().Configure(modelBuilder.Entity<PessoaVinculoEntity>());
            new ProfissaoVinculoTypeConfiguration().Configure(modelBuilder.Entity<ProfissaoVinculoEntity>());
            new CargoTypeConfiguration().Configure(modelBuilder.Entity<CargoEntity>());

            new UsuarioTypeConfiguration().Configure(modelBuilder.Entity<UsuarioEntity>());
            new HistoricoTypeConfiguration().Configure(modelBuilder.Entity<HistoricoEntity>());
        }
    }
}
