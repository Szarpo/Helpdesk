using Helpdesk.Application.Commands.TicketCommand;
using Helpdesk.Application.DTO;
using Helpdesk.Application.Queries.TicketQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    private readonly IMediator _mediator;

    public TicketController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    
    [HttpPost]
    public async Task<ActionResult> CreateTicket([FromBody] CreateTicketCommand command)
    {
        Console.WriteLine("JESTEM!");
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TicketsDto>>> GetTickets([FromQuery] GetTicketsQuery query)
    {
        return Ok(await _mediator.Send(query));
    }
}