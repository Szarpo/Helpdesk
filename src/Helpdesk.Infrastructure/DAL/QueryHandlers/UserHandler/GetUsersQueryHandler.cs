using Helpdesk.Application.DTO;
using Helpdesk.Application.Queries.UserQuery;
using Helpdesk.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Infrastructure.DAL.QueryHandlers.UserHandler;

internal sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, PagedResult<UsersDto>>
{

    private readonly HelpdeskDbContext _dbContext;

    public GetUsersQueryHandler(HelpdeskDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<PagedResult<UsersDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var usersDtos = await _dbContext.Users
            .Skip(request.PageSize * (request.PageNumber -1))
            .Take(request.PageSize)
            .Select(x => new UsersDto(
                x.Id,
                x.Email,
                x.Company,
                x.Role
                ))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        var totalCount = await _dbContext.Users.CountAsync(cancellationToken: cancellationToken);

        return new PagedResult<UsersDto>(usersDtos, totalCount, request.PageSize, request.PageNumber);
    }
}