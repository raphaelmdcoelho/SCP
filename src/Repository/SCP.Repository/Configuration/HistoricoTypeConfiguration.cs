using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCP.Domain.Historico;

namespace SCP.Repository.Configuration
{
    class HistoricoTypeConfiguration : IEntityTypeConfiguration<HistoricoEntity>
    {
        // Microsoft.EntityFrameworkCore.Relational -> Para .ToTable
        public void Configure(EntityTypeBuilder<HistoricoEntity> builder)
        {
            builder.ToTable("Historico");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Acao).HasColumnName("Acao").HasMaxLength(1).IsRequired();
            builder.Property(x => x.DthRegistro).HasColumnName("DthRegistro").IsRequired();

            builder.HasOne(historico => historico.Pessoa).WithMany(pessoa => pessoa.Historicos).HasForeignKey(documento => documento.PessoaId)
                .HasConstraintName("historico_pessoa");
            builder.HasOne(historico => historico.Usuario).WithMany(usuario => usuario.Historicos).HasForeignKey(documento => documento.UsuarioId)
                .HasConstraintName("historico_usuario");
        }
    }
}