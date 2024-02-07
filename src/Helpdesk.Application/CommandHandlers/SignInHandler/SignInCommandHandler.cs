using Helpdesk.Application.Auth;
using Helpdesk.Application.Commands.SignInCommand;
using MediatR;

namespace Helpdesk.Application.CommandHandlers.SignInHandler;

public class SignInCommandHandler : IRequestHandler<SignInCommand>
{
    private readonly ICookieAuthorizationService _cookieAuthorizationService;

    public SignInCommandHandler(ICookieAuthorizationService cookieAuthorizationService)
    {
        _cookieAuthorizationService = cookieAuthorizationService;
    }
    
    public async Task Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        await _cookieAuthorizationService.SignIn(email: request.Email, password: request.Password);
    }
}