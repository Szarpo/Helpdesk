using Helpdesk.Application.Commands.SignInCommand;
using Helpdesk.Application.Commands.SignOutCommand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Helpdesk.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("sign-in")]
    [SwaggerOperation("Login - Email / Password")]
    public async Task<ActionResult> SignIn([FromBody] SignInCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPost("sign-out")]
    [Authorize]
    [SwaggerOperation("Logout")]
    public async Task<ActionResult> SignOut(SignOutCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
    
}