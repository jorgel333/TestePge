using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.DataBase.EntitiesConfiguration;

public class AdvogadoConfiguration : IEntityTypeConfiguration<Advogado>
{
    public void Configure(EntityTypeBuilder<Advogado> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasIndex(c => c.Cpf).IsUnique();

        builder.HasIndex(c => c.Oab).IsUnique();

        builder.Property(c => c.Nome).IsRequired().HasMaxLength(120);

        builder.Property(c => c.Cpf).IsRequired().HasMaxLength(11);

        builder.Property(c => c.Oab).IsRequired().HasMaxLength(15);
    }
}
