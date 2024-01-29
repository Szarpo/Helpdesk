using Helpdesk.Core.Entities;

namespace Helpdesk.Core.Repositories;

public interface ITicketRepository
{
    Task Add(Ticket ticket);
    Task<Ticket> GetById(Guid ticketId);
    Task Delete(Ticket ticket);
    Task<bool> IsExistId(Guid ticketId);
}