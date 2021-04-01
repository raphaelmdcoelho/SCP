using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCP.Domain.Pessoa;

namespace SCP.Repository.Configuration
{
    public class PessoaTypeConfiguration : IEntityTypeConfiguration<PessoaEntity>
    {
        // Microsoft.EntityFrameworkCore.Relational -> Para .ToTable
        public void Configure(EntityTypeBuilder<PessoaEntity> builder)
        {
            builder.ToTable("Pessoa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tipo).HasColumnName("Tipo").IsRequired();
            builder.Property(x => x.IsAtivo).HasColumnName("IsAtivo").IsRequired();
            builder.Property(x => x.DthCriacao).HasColumnName("DthCriacao").IsRequired();
            builder.Property(x => x.DthExclusao).HasColumnName("DthExclusao");

            builder.HasOne(pessoa => pessoa.Usuario).WithMany(usuario => usuario.Pessoas).HasForeignKey(pessoa => pessoa.UsuarioId)
                .HasConstraintName("pessoa_usuario");
        }
    }
}
