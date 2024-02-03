using Helpdesk.Core.Entities;
using Helpdesk.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Infrastructure.DAL.Repositories;

internal sealed class TicketRepository : ITicketRepository
{

    private readonly DbSet<Core.Entities.Ticket> _tickets;
    private readonly DbSet<Comment> _comments;
    private readonly HelpdeskDbContext _dbContext;

    public TicketRepository(HelpdeskDbContext dbContext)
    {
        _dbContext = dbContext;
        _tickets = _dbContext.Tickets;
        _comments = _dbContext.Comments;
    }
    
    public async  Task Add(Ticket ticket)
    {
        await _tickets.AddAsync(ticket);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Ticket> GetById(Guid ticketId) => await _dbContext.Tickets.FirstOrDefaultAsync(x => x.Id == ticketId);
    
    public async Task Delete(Ticket ticket)
    {
        _tickets.RemoveRange(ticket);
        await _dbContext.SaveChangesAsync();
    }

    public async Task ChangeStatus(Ticket ticket)
    {
         _tickets.UpdateRange(ticket);
         await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsExistId(Guid ticketId) => await _tickets.AnyAsync(x => x.Id == ticketId);

    public async Task<bool> IsExistUserId(Guid userId) => await _tickets.AnyAsync(x => x.CreatorId == userId);
}