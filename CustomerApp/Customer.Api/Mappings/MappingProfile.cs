using AutoMapper;
using Customer.Api.Contracts;
using Customer.Api.Dtos.v1;

namespace Customer.Api.Mappings
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<IEnumerable<CustomerDto>, GetCustomersResponse>();
    }
  }
}
