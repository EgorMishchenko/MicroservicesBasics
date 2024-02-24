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
        new CustomerTable(new Guid("22874488-1c32-412f-b42b-00bc92c31c9c"), "John", "Doe", new DateOnly(1993, 01, 5)),
        new CustomerTable(new Guid("67154e1d-eff8-4d5b-b82c-4594b5be2c68"), "Peter", "Griffin", new DateOnly(1995, 04, 13)),
        new CustomerTable(new Guid("e7884e59-0aa1-4ec4-9fe1-870d993c563c"), "Kenny", "McCormick", new DateOnly(1995, 04, 13)),
        new CustomerTable(new Guid("1b232333-4a3f-4f7d-89fc-b1cf84623baa"), "Bart", "Simpson", new DateOnly(1995, 04, 13)),
        new CustomerTable(new Guid("d96db6c6-c3ec-4ce4-8c95-2499a4ea65a1"), "Bob", "Belcher", new DateOnly(1995, 04, 13)),
        new CustomerTable(new Guid("ff57c226-8d0b-4ca4-8343-452ab663bcd9"), "BoJack", "Horseman", new DateOnly(1995, 04, 13)),
        new CustomerTable(new Guid("ee6a849e-dd40-4648-9cf1-bc3bbe34f8e9"), "Philip", "Fry", new DateOnly(1995, 04, 13)),
      };

      context.AddRange(customers);
      context.SaveChanges();
    }
  }
}
