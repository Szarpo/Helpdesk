using MediatR;

namespace Helpdesk.Application.Commands.UserCommand;

public sealed record ChangeUserRoleCommand(Guid UserId, int Role) : IRequest;