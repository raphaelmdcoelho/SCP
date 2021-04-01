using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCP.Domain.Cargo;

namespace SCP.Repository.Configuration
{
    public class CargoTypeConfiguration : IEntityTypeConfiguration<CargoEntity>
    {
        // Microsoft.EntityFrameworkCore.Relational -> Para .ToTable
        public void Configure(EntityTypeBuilder<CargoEntity> builder)
        {
            builder.ToTable("Cargo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnName("Nome").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Codigo).HasColumnName("Codigo").IsRequired();

            builder.HasIndex(x => x.Codigo).IsUnique();
        }
    }
}