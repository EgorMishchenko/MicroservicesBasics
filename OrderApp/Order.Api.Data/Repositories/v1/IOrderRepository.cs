using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order.Api.Domain.Entities;

namespace Order.Api.Data.Repositories.v1
{
  public interface IOrderRepository : IRepository<OrderEntity>
  {

  }
}
