using Microsoft.EntityFrameworkCore;

namespace Customer.Api.Database.EF
{
  internal class Program
  {
    static void Main(string[] args)
    {
      using (var db = new CustomerContext())
      {
      }
    }
  }
}
