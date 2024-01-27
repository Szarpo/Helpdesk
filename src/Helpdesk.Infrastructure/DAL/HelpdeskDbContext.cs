using Helpdesk.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Infrastructure.DAL;

internal sealed class HelpdeskDbContext : DbContext
{
    public DbSet<Ticket> Tickets { get; set; }

    public HelpdeskDbContext(DbContextOptions<HelpdeskDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
    
}