using Helpdesk.Application.DTO;
using MediatR;

namespace Helpdesk.Application.Queries.UserQuery;

public record GetAuthorizeUserQuery() : IRequest<UserDto>;