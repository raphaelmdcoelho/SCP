using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCP.Domain.Documento;

namespace SCP.Repository.Configuration
{
    public class DocumentoTypeConfiguration : IEntityTypeConfiguration<DocumentoEntity>
    {
        // Microsoft.EntityFrameworkCore.Relational -> Para .ToTable
        public void Configure(EntityTypeBuilder<DocumentoEntity> builder)
        {
            builder.ToTable("Documento");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.MidiaId).HasColumnName("MidiaId").IsRequired();

            builder.Property(x => x.Tipo).HasColumnName("Tipo").IsRequired();
            builder.Property(x => x.DthRegistro).HasColumnName("DthRegistro").HasMaxLength(500).IsRequired();
            builder.Property(x => x.DthExclusao).HasColumnName("DthExclusao").HasMaxLength(10);

            builder.HasOne(documento => documento.Pessoa).WithMany(pessoa => pessoa.Documentos).HasForeignKey(documento => documento.PessoaId)
                .HasConstraintName("documento_pessoa");
            builder.HasOne(documento => documento.Midia).WithOne(midia => midia.Documento).HasForeignKey<DocumentoEntity>(midia => midia.MidiaId);
        }
    }
}