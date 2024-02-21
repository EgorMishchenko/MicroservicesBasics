using AutoMapper;
using Customer.Api.Contracts;
using Customer.Api.Dtos.v1;
using Customer.Api.Service.v1.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        var query = new GetCustomersQuery();
        IEnumerable<CustomerDto> result = await _mediator.Send(query);
        return _mapper.Map<GetCustomersResponse>(result);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
