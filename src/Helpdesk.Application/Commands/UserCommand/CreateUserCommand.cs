using MediatR;

namespace Helpdesk.Application.Commands.UserCommand;

public sealed record CreateUserCommand(string Email, string Password, string Company) : IRequest;