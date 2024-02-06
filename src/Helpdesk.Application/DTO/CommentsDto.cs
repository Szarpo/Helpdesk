namespace Helpdesk.Application.DTO;

public record CommentsDto
(
     Guid UserId,
     string Content,
     DateTime CreatedAt
);