using Helpdesk.Application.Commands.TicketCommand;
using Helpdesk.Core.Abstractions;
using Helpdesk.Core.Enums;
using Helpdesk.Core.Exceptions;
using Helpdesk.Core.Repositories;
using MediatR;

namespace Helpdesk.Application.CommandHandlers.TicketHandler;

public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand>
{

    private readonly ITicketRepository _ticketRepository;
    private readonly IClock _clock;

    public ChangeStatusCommandHandler(ITicketRepository ticketRepository, IClock clock)
    {
        _ticketRepository = ticketRepository;
        _clock = clock;
    }
    
    public async Task Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
    {
        var (ticketId, status) = request;

        var isExist = await _ticketRepository.IsExistId(ticketId);

        if (!isExist)
        {
            throw new IdNotExist($"TicketId: {ticketId}");
        }

        var ticket = await _ticketRepository.GetById(ticketId);
        
        var currentTime = _clock.Current();

        if (ticket.TicketStatus.Value is TicketStatusEnum.Open or TicketStatusEnum.Analysis or TicketStatusEnum.WorkInProgress)
        {
            ticket.ChangeStatus(
                ticketStatus: status,
                state: 0
            );
        }

        if (ticket.TicketStatus.Value is TicketStatusEnum.Solved or TicketStatusEnum.Rejected)
        {
            ticket.CloseTheTicket(
                ticketStatus: status,
                state: 1,
                closedAt: currentTime
            );
        }

        await _ticketRepository.ChangeStatus(ticket: ticket);
    }
}