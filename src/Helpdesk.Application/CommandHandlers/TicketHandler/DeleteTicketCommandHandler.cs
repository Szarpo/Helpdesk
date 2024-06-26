using Helpdesk.Application.Commands.TicketCommand;
using Helpdesk.Core.Exceptions;
using Helpdesk.Core.Repositories;
using MediatR;

namespace Helpdesk.Application.CommandHandlers.TicketHandler;

public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand>
{
    private readonly ICommentRepository _commentRepository;
    private readonly ITicketRepository _ticketRepository;

    public DeleteTicketCommandHandler(ICommentRepository commentRepository, ITicketRepository ticketRepository)
    {
        _commentRepository = commentRepository;
        _ticketRepository = ticketRepository;
    }
    
    public async Task Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _ticketRepository.IsExistId(request.TicketId);

        if (!isExist)
        {
            throw new IdNotExist($"TicketId: {request.TicketId}");
        }
        
        var ticket = await _ticketRepository.GetById(request.TicketId);
        var comments = await _commentRepository.GetCommentsWithTicketId(request.TicketId);

        await _commentRepository.Delete(comments);
        await _ticketRepository.Delete(ticket);
    }
}