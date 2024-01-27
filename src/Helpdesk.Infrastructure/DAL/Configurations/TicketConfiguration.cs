using Helpdesk.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpdesk.Infrastructure.DAL.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ComplexProperty(x => x.CreatorId);
        builder.ComplexProperty(x => x.Category);
        builder.ComplexProperty(x => x.Title);
        builder.ComplexProperty(x => x.Content);
        builder.ComplexProperty(x => x.Status);
        builder.ComplexProperty(x => x.State);
        builder.ComplexProperty(x => x.CreatedAt);
        builder.ComplexProperty(x => x.ClosedAt);
        
    }
}