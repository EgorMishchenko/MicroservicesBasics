using AutoMapper;
using Customer.Api.Data.Models;
using Customer.Api.Dtos.v1;

namespace Customer.Api.Mappings
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<IEnumerable<CustomerDto>, IEnumerable<Contracts.Customer>>();
      CreateMap<CustomerDto, Contracts.Customer>();

      CreateMap<IEnumerable<CustomerTable>, IEnumerable<CustomerDto>>();
      //CreateMap<List<CustomerTable>, List<CustomerDto>>();
      CreateMap<CustomerTable, CustomerDto>();
    }
  }
}
