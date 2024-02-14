using Helpdesk.Core.Entities;
using Helpdesk.Core.Repositories;
using Helpdesk.Core.ValueObjects;
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

    public async Task<User> GetUserByEmail(Email email) => await _users.FirstOrDefaultAsync(x => x.Email == email);
    public async Task<User> GetById(Guid userId) => await _users.FirstOrDefaultAsync(x => x.Id == userId);

    public async Task ChangeRole(User user)
    {
         _users.UpdateRange(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task ChangeActivation(User user)
    {
        _users.UpdateRange(user);
       await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsExist(Guid userId) => await _users.AnyAsync(x => x.Id == userId);
}