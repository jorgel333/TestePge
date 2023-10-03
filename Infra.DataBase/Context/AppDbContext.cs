using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.DataBase.Context;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
	{
	}
    public DbSet<ProcessoJudicial> ProcessosJudiciais { get; set; }
    public DbSet<Advogado> Advogados { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<AdvogadoCliente> AdvogadoCliente { get; set; }
    public DbSet<Documento> Documentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
