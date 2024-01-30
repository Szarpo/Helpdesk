using Helpdesk.Application.DTO;
using MediatR;

namespace Helpdesk.Application.Queries.TicketQuery;

public sealed record GetTicketByIdQuery(Guid TicketId) : IRequest<TicketDto>;