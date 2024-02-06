namespace Helpdesk.Application.DTO;

     public record TicketDto(
          Guid Id,
          Guid CreatorId,
          string Title,
          string Content,
          string Category,
          string Status,
          string State,
          DateTime? CreatedAt,
          DateTime? ClosedAt
     );
