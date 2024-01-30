using Helpdesk.Application.DTO;
using Helpdesk.Application.Queries.TicketQuery;
using Helpdesk.Infrastructure.DAL.QueryHandlers.AsDto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Infrastructure.DAL.QueryHandlers.TicketHandler;

internal sealed class GetTicketsQueryHandler : IRequestHandler<GetTicketsQuery, IEnumerable<TicketsDto>>
{
    private readonly HelpdeskDbContext _dbContext;

    public GetTicketsQueryHandler(HelpdeskDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<TicketsDto>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
    {
        var tickets =  _dbContext.Tickets.AsNoTracking().Select(x => x.TicketsAsDto());
        
        return await tickets.ToListAsync();
    }
}