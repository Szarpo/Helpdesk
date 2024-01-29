using MediatR;

namespace Helpdesk.Application.Commands.UserCommand;

public sealed record CreateUserCommand(string Email, string Company) : IRequest;