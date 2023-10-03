using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.DataBase.EntitiesConfiguration;

public class AdvogadoClienteConfiguration : IEntityTypeConfiguration<AdvogadoCliente>
{
    public void Configure(EntityTypeBuilder<AdvogadoCliente> builder)
    {
        builder.HasKey(d => d.Id);

        builder.HasOne(d => d.Cliente).WithMany(d => d.Advogados).HasForeignKey(d => d.ClienteId);

        builder.HasOne(d => d.Advogado).WithMany(d => d.Clientes).HasForeignKey(d => d.AdvogadoId);
    }
}
