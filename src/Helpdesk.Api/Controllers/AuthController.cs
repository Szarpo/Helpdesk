using Helpdesk.Application.Commands.SignInCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<ActionResult> SignIn([FromBody] SignInCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
    
}