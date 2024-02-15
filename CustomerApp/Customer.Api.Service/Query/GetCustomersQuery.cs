using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Api.Service.Query
{
  public class GetCustomersQuery : IRequest<List<Customer>>
  {
  }
}
