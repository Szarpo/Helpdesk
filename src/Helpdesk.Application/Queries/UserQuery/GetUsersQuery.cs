using Helpdesk.Application.DTO;
using MediatR;

namespace Helpdesk.Application.Queries.UserQuery;

public sealed record GetUsersQuery() : IRequest<IEnumerable<UsersDto>>;