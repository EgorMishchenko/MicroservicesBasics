using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer.Api.Data.Repository;
using FluentValidation;

namespace Customer.DomainService
{
  public sealed class CustomerValidator : AbstractValidator<CustomerEntity>
  {
    public CustomerValidator(ICustomerRepository customerRepository)
    {
      RuleFor(x => x.Email)
        .CustomAsync(async (email, context, ct) =>
          {
            if (email is null)
            {
              return;
            }
            if (email.Trim() == string.Empty)
            {
              context.AddFailure("Email empty or white space.");
            }
            else
            {
              if (await DoesEmailAlreadyExist(email, customerRepository, ct))
              {
                context.AddFailure("Email already exists.");
              }
            }
          }
        );
    }

    private async Task<bool> DoesEmailAlreadyExist(string email, ICustomerRepository customerRepository, CancellationToken token)
    {
      var customers = await customerRepository.GetCustomersByEmailAsync(email, token);
      return customers.Any();
    }
  }
}
