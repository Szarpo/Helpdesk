using Helpdesk.Application.DTO;
using Helpdesk.Application.Queries.TicketQuery;
using Helpdesk.Core.Exceptions;
using Helpdesk.Core.Repositories;
using Helpdesk.Infrastructure.DAL.QueryHandlers.AsDto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Infrastructure.DAL.QueryHandlers.TicketHandler;

internal sealed class GetTicketsByUserQueryHandler : IRequestHandler<GetTicketsByUserQuery, IEnumerable<TicketsDto>>
{
    private readonly HelpdeskDbContext _dbContext;
    private readonly ITicketRepository _ticketRepository;

    public GetTicketsByUserQueryHandler(HelpdeskDbContext dbContext, ITicketRepository ticketRepository)
    {
        _dbContext = dbContext;
        _ticketRepository = ticketRepository;
    }
    
    public async Task<IEnumerable<TicketsDto>> Handle(GetTicketsByUserQuery request, CancellationToken cancellationToken)
    {
        var isExist = await _ticketRepository.IsExistUserId(request.UserId);

        if (!isExist)
        {
            throw new IdNotExist($"UserID: {request.UserId}");
        }
        
        var tickets =  await _dbContext.Tickets.AsNoTracking().Where(x => x.CreatorId == request.UserId).Select(x => x.TicketsAsDto()).ToListAsync(cancellationToken: cancellationToken);

        return tickets;
    }
}