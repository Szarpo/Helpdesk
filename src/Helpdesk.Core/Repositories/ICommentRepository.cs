using Helpdesk.Core.Entities;

namespace Helpdesk.Core.Repositories;

public interface ICommentRepository
{
    Task Add(Comment comment);
    Task<Comment> GetById(Guid ticketId);
    Task Delete(IEnumerable<Comment> comment);
    Task<IEnumerable<Comment>> GetCommentsWithTicketId(Guid ticketId);

}