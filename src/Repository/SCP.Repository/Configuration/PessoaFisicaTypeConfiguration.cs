using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCP.Domain.PessoaFisica;

namespace SCP.Repository.Configuration
{
    public class PessoaFisicaTypeConfiguration : IEntityTypeConfiguration<PessoaFisicaEntity>
    {
        // Microsoft.EntityFrameworkCore.Relational -> Para .ToTable
        public void Configure(EntityTypeBuilder<PessoaFisicaEntity> builder)
        {
            builder.ToTable("PessoaFisica");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PessoaId).HasColumnName("PessoaId").IsRequired();

            builder.Property(x => x.PrimeiroNome).HasColumnName("PrimeiroNome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Sobrenome).HasColumnName("Sobrenome").HasMaxLength(200).IsRequired();
            builder.Property(x => x.DthNascimento).HasColumnName("DthNascimento").IsRequired();
            builder.Property(x => x.Genero).HasColumnName("Genero").HasMaxLength(1).IsRequired();
            builder.Property(x => x.CPF).HasColumnName("CPF").HasMaxLength(11).IsRequired();
            builder.Property(x => x.RG).HasColumnName("RG").HasMaxLength(7);
            builder.Property(x => x.Altura).HasColumnName("Altura").HasMaxLength(3);
            builder.Property(x => x.Peso).HasColumnName("Peso").HasMaxLength(3);

            builder.HasOne(pessoaFisica => pessoaFisica.Pessoa).WithOne(pessoa => pessoa.PessoaFisica).HasForeignKey<PessoaFisicaEntity>(pessoaFisica => pessoaFisica.PessoaId);
        }
    }
}
