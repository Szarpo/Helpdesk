using Helpdesk.Application.Commands.TicketCommand;
using Helpdesk.Application.DTO;
using Helpdesk.Application.Queries.TicketQuery;
using Helpdesk.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public async Task<ActionResult> CreateTicket([FromBody] CreateTicketCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<PagedResult<TicketsDto>>> GetTickets([FromQuery] int pageSize, [FromQuery] int pageNumber)
    {
        var query = new GetTicketsQuery(pageNumber, pageSize);
        return Ok(await _mediator.Send(query));
    }

    [HttpGet("{ticketId:guid}")]
    [Authorize]
    public async Task<ActionResult<TicketDto>> GetTicketBytId(Guid ticketId)
    {
        var query = new GetTicketByIdQuery(ticketId);
        return Ok(await _mediator.Send(query));
    }

    [HttpGet("by-user/{userId:guid}")]
    [Authorize]
    public async Task<ActionResult<PagedResult<TicketsDto>>> GetTicketsByUser(Guid userId, [FromQuery] int pageSize, [FromQuery] int pageNumber)
    {
        var query =  new GetTicketsByUserQuery(userId, pageSize, pageNumber);
        return Ok(await _mediator.Send(query));
    }

    [HttpDelete("{ticketId:guid}")]
    [Authorize(Policy = "is-admin")]
    public async Task<ActionResult> DeleteTicket(Guid ticketId)
    {
        var command = new DeleteTicketCommand(ticketId);
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut("{ticketId:guid}")]
    [Authorize(Policy = "is-agent")]
    public async Task<ActionResult> ChangeStatus(Guid ticketId, [FromQuery] int status)
    {
        var command =  new ChangeStatusCommand(ticketId, status);

        await _mediator.Send(command);
        return Ok();
    }
    
}