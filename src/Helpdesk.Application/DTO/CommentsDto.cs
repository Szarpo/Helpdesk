namespace Helpdesk.Application.DTO;

public record CommentsDto
{
    public Guid UserId { get;  set; }
    public string Content { get;  set; }
    public DateTime CreatedAt { get;  set; }
}