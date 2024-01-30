using MediatR;

namespace Helpdesk.Application.Commands.TicketCommand;

public sealed record DeleteTicketCommand(Guid TicketId) : IRequest;