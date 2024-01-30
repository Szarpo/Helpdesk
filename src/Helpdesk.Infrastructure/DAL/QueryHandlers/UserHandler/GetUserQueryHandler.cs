using Helpdesk.Application.DTO;
using Helpdesk.Application.Queries.UserQuery;
using Helpdesk.Infrastructure.DAL.QueryHandlers.AsDto;
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
        var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken: cancellationToken);

        return  user.UserAsDto();
    }
}