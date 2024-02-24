using AutoMapper;
using Customer.Api.Contracts;
using Customer.Api.Data.Models;
using Customer.Api.Dtos.v1;

namespace Customer.Api.Mappings
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<CustomerDto, Contracts.Customer>();
      CreateMap<List<CustomerDto>, GetCustomersResponse>();
      CreateMap<CustomerTable, CustomerDto>();
    }
  }
}
