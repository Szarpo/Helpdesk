using Helpdesk.Core.Entities;
using Helpdesk.Core.ValueObjects;

namespace Helpdesk.Core.Repositories;

public interface IUserRepository
{
    Task Add(User user);
    Task<User> GetUserByEmail(Email email);
    Task<User> GetById(Guid userId);
    Task ChangeRole(User user);
    Task ChangeActivation(User user);
    Task<bool> IsExist(Guid userId);
}