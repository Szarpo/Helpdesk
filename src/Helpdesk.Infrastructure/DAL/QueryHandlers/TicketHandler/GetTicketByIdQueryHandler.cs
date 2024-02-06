using Helpdesk.Application.DTO;
using Helpdesk.Application.Queries.TicketQuery;
using Helpdesk.Core.Exceptions;
using Helpdesk.Core.Models;
using Helpdesk.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Infrastructure.DAL.QueryHandlers.TicketHandler;

internal sealed class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery,TicketDto>
{
    private readonly HelpdeskDbContext _dbContext;
    private readonly ITicketRepository _ticketRepository;

    public GetTicketByIdQueryHandler(HelpdeskDbContext dbContext, ITicketRepository ticketRepository)
    {
        _dbContext = dbContext;
        _ticketRepository = ticketRepository;
    }
    
    public async Task<TicketDto> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {

        var isExist = await _ticketRepository.IsExistId(request.TicketId);
        
        if (!isExist)
        {
            throw new IdNotExist($"TicketId: {request.TicketId}");
        }

        var ticket = await _dbContext.Tickets
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.TicketId, cancellationToken: cancellationToken);

        var ticketDto = new TicketDto(
            ticket.Id, 
            ticket.CreatorId, 
            ticket.Title, 
            ticket.Content, 
            ticket.Category,
            ticket.TicketStatus, 
            ticket.State, 
            ticket.CreatedAt, 
            ticket.ClosedAt
            
            );
            

        return ticketDto;
    }
}