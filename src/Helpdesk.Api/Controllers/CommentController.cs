using Helpdesk.Application.Commands.CommentCommand;
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
    
}