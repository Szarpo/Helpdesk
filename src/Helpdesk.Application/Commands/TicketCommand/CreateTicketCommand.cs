using MediatR;

namespace Helpdesk.Application.Commands.TicketCommand;

public sealed record CreateTicketCommand(
    string Title, 
    string Content, 
    int Category
    ): IRequest;