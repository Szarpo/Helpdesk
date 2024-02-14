using Helpdesk.Application.Commands.UserCommand;
using Helpdesk.Application.DTO;
using Helpdesk.Application.Queries.UserQuery;
using Helpdesk.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{

    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [Authorize(Policy = "is-admin")]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet]
    [Authorize(Policy = "is-admin")]
    public async Task<ActionResult<PagedResult<UsersDto>>> GetUsers([FromQuery] int pageSize, int pageNumber)
    {
        var query = new GetUsersQuery(pageSize, pageNumber);
        
        return Ok(await _mediator.Send(query));
    }

    [HttpGet("{userId:guid}")]
    [Authorize]
    public async Task<ActionResult<UserDto>> GetUserById(Guid userId)
    {
        var query =  new GetUserQuery(userId);
        
        return Ok(await _mediator.Send(query));
    }

    [HttpGet("authorize-user")]
    [Authorize]
    public async Task<ActionResult<UserDto>> GetAuthorizeUser()
    {
        var query =  new GetAuthorizeUserQuery();
        
        return Ok(await _mediator.Send(query));
    }
    
}