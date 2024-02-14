using Helpdesk.Application.Commands.UserCommand;
using Helpdesk.Core.Exceptions;
using Helpdesk.Core.Repositories;
using MediatR;

namespace Helpdesk.Application.CommandHandlers.UserHandler;

public class ChangeUserActivationCommandHandler : IRequestHandler<ChangeUserActivationCommand>
{
    private readonly IUserRepository _userRepository;

    public ChangeUserActivationCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task Handle(ChangeUserActivationCommand request, CancellationToken cancellationToken)
    {
        var (userId, activation) = request;

        var isExist = await _userRepository.IsExist(userId);

        if (!isExist)
        {
            throw new IdNotExist($"User: {userId}");
        }

        var user = await _userRepository.GetById(userId);
        
        user.ChangeActivation(activation: activation);

        await _userRepository.ChangeActivation(user);

    }
}