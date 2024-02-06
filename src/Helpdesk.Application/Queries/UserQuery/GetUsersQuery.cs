using Helpdesk.Application.DTO;
using Helpdesk.Core.Models;
using MediatR;

namespace Helpdesk.Application.Queries.UserQuery;

public sealed record GetUsersQuery(int PageSize, int PageNumber) : IRequest<PagedResult<UsersDto>>;