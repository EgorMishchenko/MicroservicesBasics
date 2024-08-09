using Customer.Domain.BusinessValidation;
using Customer.Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Domain
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddDomainValidation(this IServiceCollection services)
    {
      services.AddScoped<IValidator<CustomerEntity>, CustomerValidator>();
      return services;
    }
  }
}
