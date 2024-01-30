using MediatR;

namespace Helpdesk.Application.Commands.TicketCommand;

public sealed record CreateTicketCommand(
    Guid CreatorId, 
    string Title, 
    string Content, 
    int Category
    ): IRequest;