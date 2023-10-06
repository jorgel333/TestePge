using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.DataBase.EntitiesConfiguration;

public class ProcessoJudicialConfiguration : IEntityTypeConfiguration<ProcessoJudicial>
{
    public void Configure(EntityTypeBuilder<ProcessoJudicial> builder)
    {

        builder.HasKey(p => p.Id);

        builder.Property(p => p.NumeroProcesso).IsRequired();

        builder.Property(j => j.Tema).HasMaxLength(400);

        builder.Property(j => j.ValorCausa).HasPrecision(8, 2);

        builder.HasOne(j => j.Parte).WithMany(j => j.Processos);

        builder.HasOne(j => j.AdvogadoResponsavel).WithMany(j => j.Processos);
    }
}
