using Microsoft.EntityFrameworkCore;
using Customer.Api.Data.Models;

namespace Customer.Api.Data.Contexts
{
  public class CustomerContext : DbContext
  {
    public CustomerContext() { }
    public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }

    public DbSet<CustomerTable> Customer { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server=localhost;Database=CustomerDb;Integrated Security=True;Encrypt=false");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<CustomerTable>().ToTable("Customer");
      modelBuilder.Entity<CustomerTable>(entity =>
      {
        entity.Property(e => e.Id).IsRequired();
        entity.Property(e => e.Birthday).HasColumnType("date");
        entity.Property(e => e.FirstName).IsRequired();
        entity.Property(e => e.LastName).IsRequired();
      });
    }
  }
}
