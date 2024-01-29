using Helpdesk.Application.DTO;
using MediatR;

namespace Helpdesk.Application.Queries.UserQuery;

public sealed record GetUserQuery(Guid UserId) : IRequest<UserDto>;