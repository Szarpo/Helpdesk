using Helpdesk.Core.Entities;
using Helpdesk.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Infrastructure.DAL.Repositories;

internal class CommentRepository : ICommentRepository
{
    private readonly HelpdeskDbContext _dbContext;
    private readonly DbSet<Comment> _comments;

    public CommentRepository(HelpdeskDbContext dbContext)
    {
        _dbContext = dbContext;
        _comments = dbContext.Comments;
    }
    
    public async Task Add(Comment comment)
    {
        await _comments.AddAsync(comment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Comment> GetById(Guid ticketId) => await _comments.FirstOrDefaultAsync(x => x.TicketId == ticketId);
    
    public async Task Delete(IEnumerable<Comment> comment)
    {
         _comments.RemoveRange(comment);
       await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Comment>> GetCommentsWithTicketId(Guid ticketId) => await _comments.Where(x => x.TicketId == ticketId).ToListAsync();
}