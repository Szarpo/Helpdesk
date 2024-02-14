using MediatR;

namespace Helpdesk.Application.Commands.SignInCommand;

public sealed record SignInCommand(string Email, string Password) : IRequest;