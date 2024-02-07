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
        builder.Property(x => x.Email).HasConversion(x=> x.Value, x=> new Email(x));
        builder.Property(x => x.Password).HasConversion(x => x.Value, x => new Password(x));
        builder.Property(x => x.Company).HasConversion(x=> x.Value, x=> new Company(x));
        builder.Property(x => x.Role).HasConversion(x=> x.Value, x=> new Role(x));
        builder.Property(x => x.IsActive).HasConversion(x => x.Value, x => new IsActive(x));
    }
}