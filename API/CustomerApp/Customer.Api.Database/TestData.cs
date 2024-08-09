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
        new CustomerTable(
          new Guid("22874488-1c32-412f-b42b-00bc92c31c9c"), 
          "John",
          "Doe", 
          new DateOnly(1993, 01, 5),
          "john_doe@ggmail.com",
          new List<AddressTable>()
          {
            new AddressTable(){ AddressLine1 = "Steele Ave 15", AddressLine2 = "", City = "Annapolis", State = "Maryland", Country = "USA", IsPrimary = true }
          }),

        new CustomerTable(
          new Guid("67154e1d-eff8-4d5b-b82c-4594b5be2c68"),
          "Peter",
          "Griffin", 
          new DateOnly(1995, 04, 13),
          "john_doe@ggmail.com",
          new List<AddressTable>()
          {
            new AddressTable(){AddressLine1 = "Steele Ave 32", AddressLine2 = "apt. 3", City = "Annapolis", State = "Maryland", Country = "USA", IsPrimary = true },
            new AddressTable(){AddressLine1 = "Windemere Ave 222", AddressLine2 = "", City = "Baltimore", State = "Maryland", Country = "USA", IsPrimary = false }
          }),

        new CustomerTable(
          new Guid("e7884e59-0aa1-4ec4-9fe1-870d993c563c"), 
          "Kenny", 
          "McCormick", 
          new DateOnly(1995, 04, 13),
          "john_doe@ggmail.com",
          new List<AddressTable>()
          {
            new AddressTable(){AddressLine1 = "Guilford Ave 9001", AddressLine2 = "", City = "Hagerstown", State = "Maryland", Country = "USA", IsPrimary = true },
            new AddressTable(){AddressLine1 = "Penn St 280", AddressLine2 = "", City = "Bedford", State = "Maryland", Country = "USA", IsPrimary = false },
            new AddressTable(){AddressLine1 = "Fulmer Ave 22337", AddressLine2 = "", City = "Clarksburg", State = "Maryland", Country = "USA", IsPrimary = false }
          }),

        new CustomerTable(
          new Guid("1b232333-4a3f-4f7d-89fc-b1cf84623baa"), 
          "Bart", 
          "Simpson", 
          new DateOnly(1995, 04, 13),
          "john_doe@ggmail.com",
          new List<AddressTable>()
          {
            new AddressTable(){AddressLine1 = "Ritchie Ct 1503", AddressLine2 = "", City = "Annapolis", State = "Maryland", Country = "USA", IsPrimary = true }
          }),

        new CustomerTable(
          new Guid("d96db6c6-c3ec-4ce4-8c95-2499a4ea65a1"), 
          "Bob", 
          "Belcher", 
          new DateOnly(1995, 04, 13),
          "john_doe@ggmail.com",
          new List<AddressTable>()
          {
            new AddressTable(){AddressLine1 = "Whiton Ct 1802", AddressLine2 = "", City = "Annapolis", State = "Maryland", Country = "USA", IsPrimary = true }
          }),

        new CustomerTable(
          new Guid("ff57c226-8d0b-4ca4-8343-452ab663bcd9"), 
          "BoJack", 
          "Horseman", 
          new DateOnly(1995, 04, 13),
          "john_doe@ggmail.com",
          new List<AddressTable>()
          {
            new AddressTable(){AddressLine1 = "Frederick St 601", AddressLine2 = "", City = "Cumberland", State = "Maryland", Country = "USA", IsPrimary = true }
          }),

        new CustomerTable(
          new Guid("ee6a849e-dd40-4648-9cf1-bc3bbe34f8e9"),
          "Philip", 
          "Fry",
          new DateOnly(1995, 04, 13),
          "john_doe@ggmail.com",
          new List<AddressTable>()
          {
            new AddressTable(){ AddressLine1 = "Woodberry Ln 289", AddressLine2 = "", City = "Winchester", State = "Maryland", Country = "USA", IsPrimary = true }
          }),
      };

      context.AddRange(customers);
      context.SaveChanges();
    }
  }
}
