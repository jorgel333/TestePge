using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.DataBase.EntitiesConfiguration;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasIndex(c => c.Cpf).IsUnique();

        builder.Property(c => c.Nome).IsRequired().HasMaxLength(120);

        builder.Property(c => c.Cpf).IsRequired().HasMaxLength(11);

    }
}
