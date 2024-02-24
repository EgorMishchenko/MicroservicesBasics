using AutoMapper;
using Customer.Api.Contracts;
using Customer.Api.Dtos.v1;
using Customer.Api.Service.v1.Command;
using Customer.Api.Service.v1.Query;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Customer.Api.Controllers.v1
{
  [Produces("application/json")]
  [Route("v1/[controller]")]
  [ApiController]
  public class CustomerController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CustomerController(IMapper mapper, IMediator mediator)
    {
      _mapper = mapper;
      _mediator = mediator;
    }

    /// <summary>
    /// Action to see all existing customers.
    /// </summary>
    /// <returns>Returns a list of all customers</returns>
    /// <response code="200">Returned if the customers were loaded</response>
    /// <response code="400">Returned if the customers couldn't be loaded</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<GetCustomersResponse>> GetCustomersAsync()
    {
      try
      {
        var customers = await _mediator.Send(new GetCustomersQuery());
        var customerContracts = _mapper.Map<List<Contracts.Customer>>(customers);
        return new GetCustomersResponse(customerContracts);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    /// <summary>
    /// Action to create a new customer in the database.
    /// </summary>
    /// <param name="request">Model to create a new customer</param>
    /// <returns>Returns the created customer</returns>
    /// <response code="200">Returned if the customer was created</response>
    /// <response code="400">Returned if the model couldn't be parsed or the customer couldn't be saved</response>
    /// <response code="422">Returned when the validation failed</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [HttpPost]
    public async Task<ActionResult<CreateCustomerResponse>> CreateCustomerAsync(CreateCustomerRequest request)
    {
      try
      {
        var customerDto = _mapper.Map<CustomerDto>(request);
        var createdCustomer = await _mediator.Send(new CreateCustomerCommand(customerDto));

        return _mapper.Map<CreateCustomerResponse>(createdCustomer);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
