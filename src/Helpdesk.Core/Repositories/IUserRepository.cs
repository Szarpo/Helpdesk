using Helpdesk.Core.Entities;
using Helpdesk.Core.ValueObjects;

namespace Helpdesk.Core.Repositories;

public interface IUserRepository
{
    Task Add(User user);
    Task<User> GetUser(Email email);
}