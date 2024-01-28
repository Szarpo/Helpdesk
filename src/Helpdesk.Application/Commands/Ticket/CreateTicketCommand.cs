using MediatR;

namespace Helpdesk.Application.Commands.Ticket;

public sealed record CreateTicketCommand(
    Guid CreatorId, 
    string Title, 
    string Content, 
    int Category, 
    int Status, 
    int State
    ): IRequest;