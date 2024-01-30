using Helpdesk.Application.DTO;
using Helpdesk.Application.Queries.UserQuery;
using Helpdesk.Infrastructure.DAL.QueryHandlers.AsDto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Infrastructure.DAL.QueryHandlers.UserHandler;

internal sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UsersDto>>
{

    private readonly HelpdeskDbContext _dbContext;

    public GetUsersQueryHandler(HelpdeskDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<UsersDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = _dbContext.Users.AsNoTracking().Select(x => x.UsersAsDto());
        return await users.ToListAsync(cancellationToken: cancellationToken);
    }
}