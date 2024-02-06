using Helpdesk.Application.DTO;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Models;

namespace Helpdesk.Infrastructure.DAL.QueryHandlers.AsDto;

public static class AsDto
{
    //public static TicketsDto TicketsAsDto(this Ticket entity) => new()
    //{
       // Id = entity.Id,
       // CreatorId = entity.CreatorId,
       // Title = entity.Title,
        //Content = entity.Content,
        //Category = entity.Category,
        //Status = entity.TicketStatus,
        //State = entity.State,
        //CreatedAt = entity.CreatedAt,
        //ClosedAt = entity.ClosedAt
    //};
    
    //public static TicketDto TicketByIdAsDto(this Ticket entity) => new()
   // {
       // Id = entity.Id,
       // CreatorId = entity.CreatorId,
       // Title = entity.Title,
//Content = entity.Content,
      //  Category = entity.Category,
    //    Status = entity.TicketStatus,
     //   State = entity.State,
     //   CreatedAt = entity.CreatedAt,
//ClosedAt = entity.ClosedAt
    //};

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