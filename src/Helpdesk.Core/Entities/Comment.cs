namespace Helpdesk.Core.Entities;

public class Comment
{
    public Guid Id { get; private set; }
    public Guid TicketId { get; private set; }
    public Guid UserId { get; private set; }
    public string Content { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Comment(Guid id, Guid ticketId, Guid userId, string content, DateTime createdAt)
    {
        Id = id;
        TicketId = ticketId;
        UserId = userId;
        Content = content;
        CreatedAt = createdAt;
    }
    
    public Comment() {}



    public static Comment Create(Guid ticketId, Guid userId, string content, DateTime createdAt)
    {
        return new Comment(
            id: Guid.NewGuid(),
            ticketId: ticketId,
            userId: userId,
            content: content, 
            createdAt: createdAt
            );
    }
    
}