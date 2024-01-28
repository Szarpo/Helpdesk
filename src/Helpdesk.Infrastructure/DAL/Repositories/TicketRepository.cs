using Helpdesk.Core.Entities;
using Helpdesk.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Infrastructure.DAL.Repositories;

internal sealed class TicketRepository : ITicketRepository
{

    private readonly DbSet<Core.Entities.Ticket> _titles;
    private readonly HelpdeskDbContext _dbContext;

    public TicketRepository(HelpdeskDbContext dbContext)
    {
        _dbContext = dbContext;
        _titles = _dbContext.Tickets;
    }
    
    public async  Task Add(Ticket ticket)
    {
        await _titles.AddAsync(ticket);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Ticket> GetById(Guid ticketId) => await _dbContext.Tickets.FirstOrDefaultAsync(x => x.Id == ticketId);

    public Task<bool> IsExistId(Guid ticketId)
    {
        throw new NotImplementedException();
    }

 
}