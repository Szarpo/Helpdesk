using Helpdesk.Application.DTO;
using Helpdesk.Core.Entities;

namespace Helpdesk.Infrastructure.DAL.QueryHandlers.AsDto;

public static class AsDto
{
    public static TicketsDto TicketsAsDto(this Ticket entity) => new()
    {
        Id = entity.Id,
        CreatorId = entity.CreatorId,
        Title = entity.Title,
        Content = entity.Content,
        Category = entity.Category,
        Status = entity.Status,
        State = entity.State,
        CreatedAt = entity.CreatedAt,
        ClosedAt = entity.ClosedAt
    };
    
    public static TicketDto TicketByIdAsDto(this Ticket entity) => new()
    {
        Id = entity.Id,
        CreatorId = entity.CreatorId,
        Title = entity.Title,
        Content = entity.Content,
        Category = entity.Category,
        Status = entity.Status,
        State = entity.State,
        CreatedAt = entity.CreatedAt,
        ClosedAt = entity.ClosedAt
    };
}