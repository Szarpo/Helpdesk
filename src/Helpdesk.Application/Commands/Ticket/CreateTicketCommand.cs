using MediatR;

namespace Helpdesk.Application.Commands.Ticket;

public record CreateTicketCommand(
    Guid CreatorId, 
    string Title, 
    string Content, 
    int Category, 
    int Status, 
    int State
    ): IRequest;