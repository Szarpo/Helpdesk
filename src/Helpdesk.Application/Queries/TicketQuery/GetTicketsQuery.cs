using Helpdesk.Application.DTO;
using MediatR;

namespace Helpdesk.Application.Queries.TicketQuery;

public sealed record GetTicketsQuery() : IRequest<IEnumerable<TicketsDto>>;