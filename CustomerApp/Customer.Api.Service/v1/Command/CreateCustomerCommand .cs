﻿using Customer.Api.Dtos.v1;
using MediatR;

namespace Customer.Api.Service.v1.Command
{
  public record CreateCustomerCommand(CustomerDto Customer) : IRequest<CustomerDto>;
}
