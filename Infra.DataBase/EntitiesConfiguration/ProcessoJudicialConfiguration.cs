﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.DataBase.EntitiesConfiguration;

public class ProcessoJudicialConfiguration : IEntityTypeConfiguration<ProcessoJudicial>
{
    public void Configure(EntityTypeBuilder<ProcessoJudicial> builder)
    {
        builder.HasKey(p => p .NumeroProcesso);

        builder.Property(j => j.Tema).HasMaxLength(100);

        builder.Property(j => j.ValorCausa).HasPrecision(8, 2);

        builder.Property(j => j.Descricao).IsRequired().HasMaxLength(400);

        builder.HasOne(j => j.Parte).WithMany(j => j.Processos).HasForeignKey(j => j.ClienteId);

        builder.HasOne(j => j.AdvogadoResponsavel).WithMany(j => j.Processos).HasForeignKey(j => j.AdvogadoId);
    }
}
