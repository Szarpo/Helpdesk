using Helpdesk.Core.Entities;
using Helpdesk.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Infrastructure.DAL.Repositories;

internal  class UserRepository : IUserRepository
{
    private readonly HelpdeskDbContext _dbContext;
    private readonly DbSet<User> _users;

    public UserRepository(HelpdeskDbContext dbContext)
    {
        _dbContext = dbContext;
        _users = _dbContext.Users;
    }
    
    public async Task Add(User user)
    {
        await _users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }
}