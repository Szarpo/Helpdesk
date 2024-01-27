using Helpdesk.Core.Entities;

namespace Helpdesk.Core.Repositories;

public interface ITicketRepository
{
    Task Add(Ticket ticket);
}