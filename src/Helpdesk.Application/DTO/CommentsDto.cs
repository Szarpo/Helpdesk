namespace Helpdesk.Application.DTO;

public record CommentsDto
(
     Guid CommentId,
     Guid UserId,
     string Content,
     DateTime CreatedAt
);