using Helpdesk.Core.ValueObjects;

namespace Helpdesk.Core.Entities;

public class Ticket
{
    
    public Guid Id { get; set; }
    public Guid CreatorId { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public Category Category { get; private set; }
    public Status Status { get; private set; }
    public State? State { get; private set; }
    public DateTime? CreatedAt { get; private set; } 
    public DateTime? ClosedAt { get; private set; }
    
    private Ticket(Guid id, Guid creatorId, string title, string content, Category category, Status status, State state, DateTime? createdAt, DateTime? closedAt)
    {
        Id = id;
        CreatorId = creatorId;
        Title = title;
        Content = content;
        Category = category;
        Status = status;
        State = state;
        CreatedAt = createdAt;
        ClosedAt = closedAt;
    }
    
    public Ticket() {}


    public static Ticket Create(Guid creatorId, string title, string content, Category category, Status status, State state, DateTime createdAt)
    {
        return new Ticket(
            id: Guid.NewGuid(), 
            creatorId: creatorId, 
            title: title, 
            content: content, 
            category: category, 
            status: status, 
            state: state, 
            createdAt: createdAt,
            closedAt: null
        );
    }
    
}