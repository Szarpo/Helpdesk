using Helpdesk.Application.DTO;
using Helpdesk.Application.Queries.UserQuery;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Infrastructure.DAL.QueryHandlers.UserHandler;

internal sealed class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
{

    private readonly HelpdeskDbContext _dbContext;

    public GetUserQueryHandler(HelpdeskDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken: cancellationToken);

        var userDto = new UserDto(
            user.Id,
            user.Email,
            user.Company,
            user.Role
            );

        return userDto;
    }
}