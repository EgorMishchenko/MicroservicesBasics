using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Api.Contracts;
using Order.Api.Domain.Entities;
using Order.Api.Models.v1;
using Order.Api.Service.v1.Commands;

namespace Order.Api.Controllers.v1
{
  [Produces("application/json")]
  [Route("api/v1/[controller]")]
  [ApiController]
  public sealed class OrderController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }

    /// <summary>
    ///     Action to create a new order in the database.
    /// </summary>
    /// <param name="request">Data to create a new order</param>
    /// <returns>Returns the created order</returns>
    /// <response code="200">Returned if the order was created</response>
    /// <response code="400">Returned if the model couldn't be parsed or saved</response>
    /// <response code="422">Returned when the validation failed</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [HttpPost]
    public async Task<ActionResult<OrderEntity>> CreateOrder(CreateOrderRequest request)
    {
      try
      {
        var orderModel = _mapper.Map<OrderModel>(request);
        var command = new CreateOrderCommand(orderModel);
        var result = await _mediator.Send(command);

        var response = _mapper.Map<CreateOrderResponse>(result);

        return result;
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
