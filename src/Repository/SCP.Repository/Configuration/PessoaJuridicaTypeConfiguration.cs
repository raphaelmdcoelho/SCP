using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCP.Domain.PessoaJuridica;

namespace SCP.Repository.Configuration
{
    public class PessoaJuridicaTypeConfiguration : IEntityTypeConfiguration<PessoaJuridicaEntity>
    {
        // Microsoft.EntityFrameworkCore.Relational -> Para .ToTable
        public void Configure(EntityTypeBuilder<PessoaJuridicaEntity> builder)
        {
            builder.ToTable("PessoaJuridica");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PessoaId).HasColumnName("PessoaId").IsRequired();

            builder.Property(x => x.RazaoSocial).HasColumnName("RazaoSocial").HasMaxLength(300).IsRequired();
            builder.Property(x => x.NomeFantasia).HasColumnName("NomeFantasia").HasMaxLength(300).IsRequired();
            builder.Property(x => x.CNPJ).HasColumnName("CNPJ").HasMaxLength(14).IsRequired();

            builder.HasOne(pessoaJuridica => pessoaJuridica.Pessoa).WithOne(pessoa => pessoa.PessoaJuridica).HasForeignKey<PessoaJuridicaEntity>(pessoaJuridica => pessoaJuridica.PessoaId);
        }
    }
}
