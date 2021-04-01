using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCP.Domain.Profissao;

namespace SCP.Repository.Configuration
{
    public class ProfissaoTypeConfiguration : IEntityTypeConfiguration<ProfissaoEntity>
    {
        // Microsoft.EntityFrameworkCore.Relational -> Para .ToTable
        public void Configure(EntityTypeBuilder<ProfissaoEntity> builder)
        {
            builder.ToTable("Profissao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnName("Nome").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Codigo).HasColumnName("Codigo").HasMaxLength(5).IsRequired();

            builder.HasIndex(x => x.Codigo).IsUnique();
        }
    }
}
