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
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
  }
}
