using Helpdesk.Application.Commands.CommentCommand;
using Helpdesk.Core.Abstractions;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Repositories;
using MediatR;

namespace Helpdesk.Application.CommandHandlers.CommentHandler;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
{

    private readonly ICommentRepository _commentRepository;
    private readonly IClock _clock;

    public CreateCommentCommandHandler(ICommentRepository commentRepository, IClock clock)
    {
        _commentRepository = commentRepository;
        _clock = clock;
    }
    
    public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var currentTime =  _clock.Current().AddHours(1);
        
        var (ticketId, userId, content) = request;

        var comment = Comment.Create(
            ticketId: ticketId,
            userId: userId,
            content: content,
            createdAt: currentTime
            );

        await _commentRepository.Add(comment);
    }
}