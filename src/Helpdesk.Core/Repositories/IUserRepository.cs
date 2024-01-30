using Helpdesk.Core.Entities;

namespace Helpdesk.Core.Repositories;

public interface IUserRepository
{
    Task Add(User user);
}