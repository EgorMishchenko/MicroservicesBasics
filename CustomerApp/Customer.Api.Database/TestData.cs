using Customer.Api.Data.Contexts;
using Customer.Api.Data.Models;

namespace Customer.Api.Database
{
  internal static class TestData
  {
    internal static void Seed(CustomerContext context)
    {
      var customers = new List<CustomerTable>()
      {
        new CustomerTable(new Guid("22874488-1c32-412f-b42b-00bc92c31c9c"), "Alice", "Cringe", new DateOnly(1993, 01, 5), 30),
        new CustomerTable(new Guid("67154e1d-eff8-4d5b-b82c-4594b5be2c68"), "Mary", "Dick", new DateOnly(1995, 04, 13), 28),
      };

      context.AddRange(customers);
      context.SaveChanges();
    }
  }
}
