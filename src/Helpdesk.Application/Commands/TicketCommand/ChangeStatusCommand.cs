using MediatR;

namespace Helpdesk.Application.Commands.TicketCommand;

public record ChangeStatusCommand(Guid TicketId, int Status) : IRequest;