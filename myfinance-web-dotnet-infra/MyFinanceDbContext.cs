using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities;

namespace myfinance_web_dotnet_infra;

public class MyFinanceDbContext : DbContext
{
  public DbSet<PlanAccount>? PlanAccount { get; set; }
  public DbSet<Transaction>? Transaction { get; set; }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
	optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=myfinance;Username=postgres;Password=12345678");
	base.OnConfiguring(optionsBuilder);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
	modelBuilder.Entity<PlanAccount>(e => e.ToTable("planaccount"));
	modelBuilder.Entity<Transaction>(e => e.ToTable("transaction"));
	base.OnModelCreating(modelBuilder);
  }
}
