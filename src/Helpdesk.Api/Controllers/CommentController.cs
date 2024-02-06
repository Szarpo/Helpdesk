using Helpdesk.Application.Commands.CommentCommand;
using Helpdesk.Application.DTO;
using Helpdesk.Application.Queries.CommentQuery;
using Helpdesk.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly IMediator _mediator;

    public CommentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> CreateComment([FromBody] CreateCommentCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet("{ticketId:guid}")]
    public async Task<ActionResult<PagedResult<CommentsDto>>> GetAllCommentByTicketId(Guid ticketId, [FromQuery] int pageSize, int pageNumber)
    {
        var query = new GetCommentsToTicketQuery(ticketId, pageSize, pageNumber);
        return Ok(await _mediator.Send(query));
    }
}