using Helpdesk.Application.Auth;
using Helpdesk.Application.Commands.SignOutCommand;
using MediatR;

namespace Helpdesk.Application.CommandHandlers.SignOutHandler;

public class SignOutCommandHandler : IRequestHandler<SignOutCommand>
{
    private readonly ICookieAuthorizationService _cookieAuthorizationService;

    public SignOutCommandHandler(ICookieAuthorizationService cookieAuthorizationService)
    {
        _cookieAuthorizationService = cookieAuthorizationService;
    }

    public async Task Handle(SignOutCommand request, CancellationToken cancellationToken) => await _cookieAuthorizationService.SignOut();
}