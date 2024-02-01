using Helpdesk.Application.Commands.UserCommand;
using Helpdesk.Application.Security;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Repositories;
using MediatR;

namespace Helpdesk.Application.CommandHandlers.UserHandler;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordManager _passwordManager;

    public CreateUserCommandHandler(IUserRepository userRepository, IPasswordManager passwordManager)
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
    }
    
    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var ( email, password, company) = request;
        
        var securePassword =  _passwordManager.Secure(password);
        

        var user = User.Create(
            email: email,
            password: securePassword,
            company: company,
            role: 0,
            status: 0
            );

        await _userRepository.Add(user);

    }
}