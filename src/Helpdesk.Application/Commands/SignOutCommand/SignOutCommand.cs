using MediatR;

namespace Helpdesk.Application.Commands.SignOutCommand;

public sealed record SignOutCommand() : IRequest;
