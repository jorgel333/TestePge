using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.DataBase.EntitiesConfiguration;

public class ProcessoJudicialConfiguration : IEntityTypeConfiguration<ProcessoJudicial>
{
    public void Configure(EntityTypeBuilder<ProcessoJudicial> builder)
    {
        builder.HasKey(j => j.Id);

        builder.HasIndex(j => j.NumeroProcesso).IsUnique();

        builder.Property(j => j.NumeroProcesso).IsRequired().HasMaxLength(60);

        builder.Property(j => j.Tema).HasMaxLength(400);

        builder.Property(j => j.ValorCausa).HasPrecision(8, 2);

        builder.HasOne(j => j.Parte).WithMany(j => j.Processos).HasForeignKey( j => j.ClienteId);

        builder.HasOne(j => j.AdvogadoResponsavel).WithMany(j => j.Processos).HasForeignKey( j => j.AdvogadoId);

        builder.HasMany(j => j.Documentos).WithOne(j => j.Processo).HasForeignKey(j => j.ProcessoId);
    }
}
