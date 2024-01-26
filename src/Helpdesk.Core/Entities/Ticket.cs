using Helpdesk.Core.ValueObjects;

namespace Helpdesk.Core.Entities;

public class Ticket
{
    
    public Guid Id { get; set; }
    public string CreatedBy { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public Category Category { get; private set; }
    public Status Status { get; private set; }
    public string State { get; set; }
    public DateTime? CreatedAt { get; private set; } 
    public DateTime? ClosedAt { get; private set; }
    
    private Ticket(Guid id, string createdBy, string title, string content, Category category, Status status, string state, DateTime? createdAt, DateTime? closedAt)
    {
        Id = id;
        CreatedBy = createdBy;
        Title = title;
        Content = content;
        Category = category;
        Status = status;
        State = state;
        CreatedAt = createdAt;
        ClosedAt = closedAt;
    }
    
    public Ticket() {}
    
    


    
}