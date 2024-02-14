using System.Security.Authentication;
using Helpdesk.Application.Commands.TicketCommand;
using Helpdesk.Core.Abstractions;
using Helpdesk.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Helpdesk.Application.CommandHandlers.TicketHandler;

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand>
{

    private readonly ITicketRepository _ticketRepository;
    private readonly IClock _clock;
    private readonly IHttpContextAccessor _contextAccessor;
    

    public CreateTicketCommandHandler(ITicketRepository ticketRepository, IClock clock, IHttpContextAccessor contextAccessor)
    {
        _ticketRepository = ticketRepository;
        _clock = clock;
        _contextAccessor = contextAccessor;
    }
    
    public async Task Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        if (_contextAccessor.HttpContext.User.Identity!.Name is null)
        {
            throw new InvalidCredentialException();
        }

        var userId =  Guid.Parse(_contextAccessor.HttpContext.User.Identity.Name);
        
        var (title, content,category) = request;

        var currentTime = _clock.Current().AddHours(1);
        
        var createTicket = Core.Entities.Ticket.Create(
            creatorId: userId,
            title: title,
            content: content,
            category: category,
            ticketStatus: 0,
            state: 0,
            createdAt: currentTime
        );

        await _ticketRepository.Add(createTicket);
    }
}