namespace Helpdesk.Application.DTO;

public record TicketDto
{
    public Guid Id { get; set; }
    public Guid CreatorId { get;  set; }
    public string Title { get;  set; }
    public string Content { get;  set; }
    public string Category { get;  set; }
    public string Status { get;  set; }
    public string State { get;  set; }
    public DateTime? CreatedAt { get;  set; } 
    public DateTime? ClosedAt { get;  set; }
}