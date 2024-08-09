using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Api.Database.EF.Tables
{
  public record CustomerTable(Guid Id, string FirstName, string LastName, DateOnly? Birthday);
}
