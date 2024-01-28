using Helpdesk.Application.Commands.TicketCommand;
using Helpdesk.Core.Abstractions;
using Helpdesk.Core.Repositories;
using MediatR;

namespace Helpdesk.Application.Commands.Handlers.TicketHandler;

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand>
{

    private readonly ITicketRepository _ticketRepository;
    private readonly IClock _clock;

    public CreateTicketCommandHandler(ITicketRepository ticketRepository, IClock clock)
    {
        _ticketRepository = ticketRepository;
        _clock = clock;
    }
    
    public async Task Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var (creatorId, title, content,category,status, state) = request;

        var currentTime = _clock.Current().AddHours(1);
        
        var createTicket = Core.Entities.Ticket.Create(
            creatorId: creatorId,
            title: title,
            content: content,
            category: category,
            status: status,
            state: state,
            createdAt: currentTime
        );

        await _ticketRepository.Add(createTicket);
    }
}