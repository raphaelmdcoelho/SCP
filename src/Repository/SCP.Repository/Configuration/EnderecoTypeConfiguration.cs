using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCP.Domain.Localizacao.Endereco;

namespace SCP.Repository.Configuration
{
    public class EnderecoTypeConfiguration : IEntityTypeConfiguration<EnderecoEntity>
    {
        // Microsoft.EntityFrameworkCore.Relational -> Para .ToTable
        public void Configure(EntityTypeBuilder<EnderecoEntity> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsCorrespondencia).HasColumnName("IsCorrespondencia").IsRequired();
            builder.Property(x => x.Logradouro).HasColumnName("Logradouro").HasMaxLength(500).IsRequired();
            builder.Property(x => x.NumeroPorta).HasColumnName("NumeroPorta").HasMaxLength(10);
            builder.Property(x => x.Cep).HasColumnName("Cep").HasMaxLength(8).IsRequired();

            builder.HasOne(endereco => endereco.Pessoa).WithMany(pessoa => pessoa.Enderecos).HasForeignKey(endereco => endereco.PessoaId)
                .HasConstraintName("endereco_pessoa");
        }
    }
}
