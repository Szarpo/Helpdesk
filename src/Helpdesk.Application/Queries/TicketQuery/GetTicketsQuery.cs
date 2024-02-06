using Helpdesk.Application.DTO;
using Helpdesk.Core.Models;
using MediatR;

namespace Helpdesk.Application.Queries.TicketQuery;

public sealed record GetTicketsQuery(int PageNumber, int PageSize) : IRequest<PagedResult<TicketsDto>>;