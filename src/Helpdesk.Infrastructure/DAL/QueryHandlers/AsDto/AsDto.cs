using Helpdesk.Application.DTO;
using Helpdesk.Core.Entities;

namespace Helpdesk.Infrastructure.DAL.QueryHandlers.AsDto;

public static class AsDto
{
 

    public static CommentsDto CommentsByTicketId(this Comment entity) => new()
    {
        UserId = entity.UserId,
        Content = entity.Content,
        CreatedAt = entity.CreatedAt,
    };

    public static UsersDto UsersAsDto(this User entity) => new()
    {
        Id = entity.Id,
        Email = entity.Email,
        Company = entity.Company,
        Role = entity.Role
    };
    
    public static UserDto UserAsDto(this User entity) => new()
    {
        Id = entity.Id,
        Email = entity.Email,
        Company = entity.Company,
        Role = entity.Role
    };

}