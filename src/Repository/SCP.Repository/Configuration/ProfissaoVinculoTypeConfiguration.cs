using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCP.Domain.ProfissaoVinculo;

namespace SCP.Repository.Configuration
{
    public class ProfissaoVinculoTypeConfiguration : IEntityTypeConfiguration<ProfissaoVinculoEntity>
    {
        // Microsoft.EntityFrameworkCore.Relational -> Para .ToTable
        public void Configure(EntityTypeBuilder<ProfissaoVinculoEntity> builder)
        {
            builder.ToTable("ProfissaoVinculo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PessoaFisicaId).HasColumnName("PessoaFisicaId").IsRequired();
            builder.Property(x => x.ProfissaoId).HasColumnName("ProfissaoId").IsRequired();
            builder.Property(x => x.CargoId).HasColumnName("CargoId");

            builder.Property(x => x.Salario).HasColumnName("Salario").HasMaxLength(15).IsRequired();
            builder.Property(x => x.DthInicio).HasColumnName("DthInicio").IsRequired();
            builder.Property(x => x.DthDesligamento).HasColumnName("DthDesligamento");
            builder.Property(x => x.DthExclusao).HasColumnName("DthExclusao");

            builder.HasOne(ProfissaoVinculo => ProfissaoVinculo.PessoaFisica).WithMany(pessoaFisica => pessoaFisica.Profissoes).HasForeignKey(ProfissaoVinculo => ProfissaoVinculo.PessoaFisicaId)
                .HasConstraintName("profissao_vinculo_pessoa_fisica");

            builder.HasOne(ProfissaoVinculo => ProfissaoVinculo.Profissao).WithMany(profissao => profissao.ProfissoesVinculos).HasForeignKey(ProfissaoVinculo => ProfissaoVinculo.ProfissaoId)
                .HasConstraintName("profissao_vinculo_profissao");

            builder.HasOne(ProfissaoVinculo => ProfissaoVinculo.Cargo).WithMany(cargo => cargo.ProfissoesVinculos).HasForeignKey(ProfissaoVinculo => ProfissaoVinculo.CargoId)
                .HasConstraintName("profissao_vinculo_cargo");
        }
    }
}
