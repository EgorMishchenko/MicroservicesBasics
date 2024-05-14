using Customer.Api.Database.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace Customer.Api.Database.EF
{
  internal class CustomerContext : DbContext
  {
    public DbSet<CustomerTable> Customers { get; set; }
  }
}
