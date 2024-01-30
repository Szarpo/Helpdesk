using Helpdesk.Core.Entities;
using Helpdesk.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpdesk.Infrastructure.DAL.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Email);
        builder.Property(x => x.Company);
        builder.Property(x => x.Role).HasConversion(x=> x.Value, x=> new Role(x));
    }
}