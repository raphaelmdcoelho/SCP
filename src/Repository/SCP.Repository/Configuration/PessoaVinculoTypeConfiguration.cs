using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCP.Domain.PessoaVinculo;

namespace SCP.Repository.Configuration
{
    public class PessoaVinculoTypeConfiguration : IEntityTypeConfiguration<PessoaVinculoEntity>
    {
        // Microsoft.EntityFrameworkCore.Relational -> Para .ToTable
        public void Configure(EntityTypeBuilder<PessoaVinculoEntity> builder)
        {
            builder.ToTable("PessoaVinculo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PessoaFisicaId).HasColumnName("PessoaFisicaId").IsRequired();
            builder.Property(x => x.PessoaJuridicaId).HasColumnName("PessoaJuridicaId").IsRequired();

            builder.Property(x => x.TipoVinculo).HasColumnName("TipoVinculo").IsRequired();
            builder.Property(x => x.DthRegistro).HasColumnName("DthRegistro").IsRequired();
            builder.Property(x => x.DthExclusao).HasColumnName("DthExclusao");
            builder.Property(x => x.IsAtivo).HasColumnName("IsAtivo").IsRequired();

            builder.HasOne(pessoaVinculada => pessoaVinculada.PessoaFisica).WithMany(pessoaFisica => pessoaFisica.EmpresasVinculadas).HasForeignKey(pessoaVinculada => pessoaVinculada.PessoaFisicaId)
                .HasConstraintName("pessoa_vinculo_pessoa_fisica");
            builder.HasOne(pessoaVinculada => pessoaVinculada.PessoaJuridica).WithMany(pessoaJuridica => pessoaJuridica.Socios).HasForeignKey(pessoaVinculada => pessoaVinculada.PessoaJuridicaId)
                .HasConstraintName("documento_vinculo_pessoa_juridica").OnDelete(DeleteBehavior.Restrict);
        }
    }
}
