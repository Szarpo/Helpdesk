using Helpdesk.Application.Commands.CommentCommand;
using Helpdesk.Application.DTO;
using Helpdesk.Application.Queries.CommentQuery;
using Helpdesk.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
    [Authorize]
    [SwaggerOperation("Add comment to ticket")]
    public async Task<ActionResult> CreateComment([FromBody] CreateCommentCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet("{ticketId:guid}")]
    [Authorize]
    [SwaggerOperation("Get all comment by ticket ID")]
    public async Task<ActionResult<PagedResult<CommentsDto>>> GetAllCommentByTicketId(Guid ticketId, [FromQuery] int pageSize, int pageNumber)
    {
        var query = new GetCommentsToTicketQuery(ticketId, pageSize, pageNumber);
        return Ok(await _mediator.Send(query));
    }
}