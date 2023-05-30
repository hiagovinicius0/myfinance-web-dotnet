using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using myfinance_web_dotnet_domain.Entities;

namespace myfinance_web_dotnet_infra;

public class MyFinanceDbContext : DbContext
{
  private readonly IConfiguration? _configuration;
  public DbSet<PlanAccount>? PlanAccount { get; set; }
  public DbSet<Transaction>? Transaction { get; set; }

  public MyFinanceDbContext(IConfiguration? configuration)
  {
	_configuration = configuration;
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
	optionsBuilder.UseNpgsql(_configuration!.GetConnectionString("Database"));
	base.OnConfiguring(optionsBuilder);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
	modelBuilder.Entity<PlanAccount>(e => e.ToTable("planaccount"));
	modelBuilder.Entity<Transaction>(e => e.ToTable("transaction"));
	base.OnModelCreating(modelBuilder);
  }
}
