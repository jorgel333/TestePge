using Microsoft.EntityFrameworkCore;

namespace Infra.DataBase.Context;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
	{
		
	}
    public DbSet<Admin> Administrators { get; set; }
    public DbSet<User> CommonUsers { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<AssessmentRecord> AssessmentRecords { get; set; }
    public DbSet<Casts> Casts { get; set; }
    public DbSet<CastActMovies> CastActMovies { get; set; }
    public DbSet<CastDirectMovies> CastDirectMovies { get; set; }
    public DbSet<Genre> Genres { get; set; }
}
