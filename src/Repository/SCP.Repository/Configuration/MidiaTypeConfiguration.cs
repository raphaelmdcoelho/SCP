using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCP.Domain.Midia;

namespace SCP.Repository.Configuration
{
    class MidiaTypeConfiguration : IEntityTypeConfiguration<MidiaEntity>
    {
        // Microsoft.EntityFrameworkCore.Relational -> Para .ToTable
        public void Configure(EntityTypeBuilder<MidiaEntity> builder)
        {
            builder.ToTable("Midia");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnName("Nome").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Conteudo).HasColumnName("Conteudo").IsRequired();
            builder.Property(x => x.Extensao).HasColumnName("Extensao").HasMaxLength(5);
        }
    }
}
