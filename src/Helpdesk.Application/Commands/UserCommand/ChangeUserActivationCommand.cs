using MediatR;

namespace Helpdesk.Application.Commands.UserCommand;

public sealed record ChangeUserActivationCommand(Guid UserId, bool Activation) : IRequest;