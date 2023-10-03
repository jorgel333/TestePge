using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.DataBase.EntitiesConfiguration;

public class DocumentoConfiguration : IEntityTypeConfiguration<Documento>
{
    public void Configure(EntityTypeBuilder<Documento> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Nome).IsRequired().HasMaxLength(100);

        builder.Property(d => d.Caminho).IsRequired().HasMaxLength(200);

        builder.Property(d => d.Extensao).IsRequired().HasMaxLength(20);

        builder.HasOne(d => d.Processo).WithMany(d => d.Documentos).HasForeignKey(d => d.ProcessoId);
    }
}
