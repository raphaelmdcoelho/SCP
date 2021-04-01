using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCP.Domain.Contato;

namespace SCP.Repository.Configuration
{
    public class ContatoTypeConfiguration : IEntityTypeConfiguration<ContatoEntity>
    {
        // Microsoft.EntityFrameworkCore.Relational -> Para .ToTable
        public void Configure(EntityTypeBuilder<ContatoEntity> builder)
        {
            builder.ToTable("Contato");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PessoaId).HasColumnName("PessoaId").IsRequired();

            builder.Property(x => x.DDD).HasColumnName("DDD").HasMaxLength(3).IsRequired();
            builder.Property(x => x.Numero).HasColumnName("Numero").HasMaxLength(500).IsRequired();
            builder.Property(x => x.Tipo).HasColumnName("Tipo").HasMaxLength(1).IsRequired();

            builder.HasOne(contato => contato.Pessoa).WithMany(pessoa => pessoa.Contatos).HasForeignKey(endereco => endereco.PessoaId)
                .HasConstraintName("contato_pessoa");
        }
    }
}
