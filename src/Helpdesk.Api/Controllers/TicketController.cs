using Helpdesk.Application.Commands;
using Helpdesk.Application.Commands.Ticket;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Api.Controllers;


[Route("ticket")]
[ApiController]
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
        await _mediator.Send(command);
        return NoContent();
    }
}