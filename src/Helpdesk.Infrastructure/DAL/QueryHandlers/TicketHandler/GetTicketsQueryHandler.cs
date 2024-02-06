using Helpdesk.Application.DTO;
using Helpdesk.Application.Queries.TicketQuery;
using Helpdesk.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Infrastructure.DAL.QueryHandlers.TicketHandler;

internal sealed class GetTicketsQueryHandler : IRequestHandler<GetTicketsQuery, PagedResult<TicketsDto>>
{
    private readonly HelpdeskDbContext _dbContext;

    public GetTicketsQueryHandler(HelpdeskDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<PagedResult<TicketsDto>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
    {
        var ticketDtosDto = await _dbContext.Tickets
            .Skip(request.PageSize * (request.PageNumber - 1))
            .Take(request.PageSize)
            .Select(x=> new TicketsDto(x.Id, x.CreatorId, x.Title, x.Content, x.Category, x.TicketStatus, x.State, x.CreatedAt, x.ClosedAt) )
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        var totalCount = await _dbContext.Tickets.CountAsync(cancellationToken: cancellationToken);

        return new PagedResult<TicketsDto>(ticketDtosDto, totalCount, request.PageSize, request.PageNumber);
    }
}