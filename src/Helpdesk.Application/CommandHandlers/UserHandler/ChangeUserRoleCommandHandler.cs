using Helpdesk.Application.Commands.UserCommand;
using Helpdesk.Core.Exceptions;
using Helpdesk.Core.Repositories;
using MediatR;

namespace Helpdesk.Application.CommandHandlers.UserHandler;

public class ChangeUserRoleCommandHandler : IRequestHandler<ChangeUserRoleCommand>
{

    private readonly IUserRepository _userRepository;

    public ChangeUserRoleCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task Handle(ChangeUserRoleCommand request, CancellationToken cancellationToken)
    {
        var (userId, role) = request;

        var isExist = await _userRepository.IsExist(userId);

        if (!isExist)
        {
            throw new IdNotExist($"User: {userId}");
        }

        var user = await _userRepository.GetById(userId);

        user.ChangeRole(role: role);

         await _userRepository.ChangeRole(user);
    }
}