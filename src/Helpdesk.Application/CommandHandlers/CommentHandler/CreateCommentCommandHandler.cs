using System.Security.Authentication;
using Helpdesk.Application.Commands.CommentCommand;
using Helpdesk.Core.Abstractions;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Helpdesk.Application.CommandHandlers.CommentHandler;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
{

    private readonly ICommentRepository _commentRepository;
    private readonly IClock _clock;
    private readonly IHttpContextAccessor _contextAccessor;

    public CreateCommentCommandHandler(ICommentRepository commentRepository, IClock clock, IHttpContextAccessor contextAccessor)
    {
        _commentRepository = commentRepository;
        _clock = clock;
        _contextAccessor = contextAccessor;
    }
    
    public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {

        if (_contextAccessor.HttpContext.User.Identity!.Name is null)
        {
            throw new InvalidCredentialException();
        }

        var creatorId = Guid.Parse(_contextAccessor.HttpContext.User.Identity.Name);
        
        var currentTime =  _clock.Current().AddHours(1);
        
        var (ticketId, content) = request;

        var comment = Comment.Create(
            ticketId: ticketId,
            userId: creatorId,
            content: content,
            createdAt: currentTime
            );

        await _commentRepository.Add(comment);
    }
}