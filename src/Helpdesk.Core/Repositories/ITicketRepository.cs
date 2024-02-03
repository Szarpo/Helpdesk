using Helpdesk.Core.Entities;

namespace Helpdesk.Core.Repositories;

public interface ITicketRepository
{
    Task Add(Ticket ticket);
    Task<Ticket> GetById(Guid ticketId);
    Task Delete(Ticket ticket);
    Task ChangeStatus(Ticket ticket);
    Task<bool> IsExistId(Guid ticketId);
    Task<bool> IsExistUserId(Guid userId);
}