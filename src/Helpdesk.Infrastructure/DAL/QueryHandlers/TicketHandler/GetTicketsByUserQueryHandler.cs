using Helpdesk.Application.DTO;
using Helpdesk.Application.Queries.TicketQuery;
using Helpdesk.Infrastructure.DAL.QueryHandlers.AsDto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Infrastructure.DAL.QueryHandlers.TicketHandler;

internal sealed class GetTicketsByUserQueryHandler : IRequestHandler<GetTicketsByUserQuery, IEnumerable<TicketsDto>>
{
    private readonly HelpdeskDbContext _dbContext;

    public GetTicketsByUserQueryHandler(HelpdeskDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<TicketsDto>> Handle(GetTicketsByUserQuery request, CancellationToken cancellationToken)
    {
        var tickets =  await _dbContext.Tickets.AsNoTracking().Where(x => x.CreatorId == request.UserId).Select(x => x.TicketsAsDto()).ToListAsync(cancellationToken: cancellationToken);

        return tickets;
    }
}