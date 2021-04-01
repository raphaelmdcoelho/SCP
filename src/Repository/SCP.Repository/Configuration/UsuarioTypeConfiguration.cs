using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCP.Domain.Usuario;

namespace SCP.Repository.Configuration
{
    public class UsuarioTypeConfiguration : IEntityTypeConfiguration<UsuarioEntity>
    {
        // Microsoft.EntityFrameworkCore.Relational -> Para .ToTable
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username).HasColumnName("Username").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Senha).HasColumnName("Senha").IsRequired();
            builder.Property(x => x.Salt).HasColumnName("Salt").IsRequired();
            builder.Property(x => x.Papel).HasColumnName("Papel").IsRequired();
        }
    }
}