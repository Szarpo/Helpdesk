using Helpdesk.Application.DTO;
using Helpdesk.Core.Models;
using MediatR;

namespace Helpdesk.Application.Queries.TicketQuery;

public record GetTicketsAuthorizeUserQuery(int PageSize, int PageNumber) : IRequest<PagedResult<TicketsDto>>;