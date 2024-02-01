using Helpdesk.Core.Entities;
using Helpdesk.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpdesk.Infrastructure.DAL.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Category).HasConversion(x=> x.Value, x=> new Category(x));
        builder.Property(x => x.Title);
        builder.Property(x => x.CreatorId);
        builder.Property(x => x.Content);
        builder.Property(x => x.TicketStatus).HasConversion(x=> x.Value, x=> new TicketStatus(x));
        builder.Property(x => x.State).HasConversion(x=> x.Value, x=> new State(x));
        builder.Property(x => x.CreatedAt);
        builder.Property(x => x.ClosedAt);

    }
}