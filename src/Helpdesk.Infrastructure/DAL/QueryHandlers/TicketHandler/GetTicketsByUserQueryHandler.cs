using Helpdesk.Application.DTO;
using Helpdesk.Application.Queries.TicketQuery;
using Helpdesk.Core.Exceptions;
using Helpdesk.Core.Models;
using Helpdesk.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Infrastructure.DAL.QueryHandlers.TicketHandler;

internal sealed class GetTicketsByUserQueryHandler : IRequestHandler<GetTicketsByUserQuery, PagedResult<TicketsDto>>
{
    private readonly HelpdeskDbContext _dbContext;
    private readonly ITicketRepository _ticketRepository;

    public GetTicketsByUserQueryHandler(HelpdeskDbContext dbContext, ITicketRepository ticketRepository)
    {
        _dbContext = dbContext;
        _ticketRepository = ticketRepository;
    }
    
    public async Task<PagedResult<TicketsDto>> Handle(GetTicketsByUserQuery request, CancellationToken cancellationToken)
    {
        var isExist = await _ticketRepository.IsExistUserId(request.UserId);

        if (!isExist)
        {
            throw new IdNotExist($"UserID: {request.UserId}");
        }
        
        var ticketsDtos =  await _dbContext.Tickets
            .Skip(request.PageSize * (request.PageNumber -1))
            .Take(request.PageSize)
            .Where(x => x.CreatorId == request.UserId)
            .Select(x => new TicketsDto(x.Id, x.CreatorId, x.Title, x.Content, x.Category, x.TicketStatus, x.State, x.CreatedAt, x.ClosedAt))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        var totalCount = await _dbContext.Tickets.CountAsync(cancellationToken: cancellationToken);

        return new PagedResult<TicketsDto>(ticketsDtos, totalCount, request.PageSize, request.PageNumber);
    }
}