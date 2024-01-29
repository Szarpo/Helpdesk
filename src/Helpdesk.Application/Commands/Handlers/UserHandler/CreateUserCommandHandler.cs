using System.ComponentModel.DataAnnotations;
using Helpdesk.Application.Commands.UserCommand;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Repositories;
using MediatR;

namespace Helpdesk.Application.Commands.Handlers.UserHandler;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var ( email, company) = request;

        var user = User.Create(
            email: email,
            company: company,
            role: 0
            );

        await _userRepository.Add(user);

    }
}