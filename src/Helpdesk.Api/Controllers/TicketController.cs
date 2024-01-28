using Helpdesk.Application.Commands.Ticket;
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
}