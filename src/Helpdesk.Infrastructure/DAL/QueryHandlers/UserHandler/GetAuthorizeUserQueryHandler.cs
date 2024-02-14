using System.Security.Authentication;
using Helpdesk.Application.DTO;
using Helpdesk.Application.Queries.UserQuery;
using Helpdesk.Core.Exceptions;
using Helpdesk.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Infrastructure.DAL.QueryHandlers.UserHandler;

internal sealed class GetAuthorizeUserQueryHandler : IRequestHandler<GetAuthorizeUserQuery, UserDto>
{
    private readonly HelpdeskDbContext _dbContext;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IUserRepository _userRepository;

    public GetAuthorizeUserQueryHandler(HelpdeskDbContext dbContext, IHttpContextAccessor contextAccessor, IUserRepository userRepository)
    {
        _dbContext = dbContext;
        _contextAccessor = contextAccessor;
        _userRepository = userRepository;
    }
    
    public async Task<UserDto> Handle(GetAuthorizeUserQuery request, CancellationToken cancellationToken)
    {

        if (_contextAccessor.HttpContext?.User.Identity?.Name is null)
        {
            throw new InvalidCredentialException();
        }
        
        var userId = Guid.Parse(_contextAccessor.HttpContext.User.Identity.Name);

        var isExist = await _userRepository.IsExist(userId);

        if (!isExist)
        {
            throw new IdNotExist($"User: {userId}");
        }

        var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == userId, cancellationToken: cancellationToken);

        var userDto =  new UserDto(
            Id: user.Id,
            Email: user.Email,
            Company: user.Company,
            Role: user.Role
        );

        return userDto;

    }
}