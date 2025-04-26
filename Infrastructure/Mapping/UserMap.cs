using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
namespace Infrastructure.Mapping;

internal sealed class UserMap :
    IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.Ignore(i => i.EmailConfirmed);
        builder.Ignore(i => i.PhoneNumberConfirmed);
        builder.Ignore(i => i.LockoutEnabled);
        builder.Ignore(i => i.LockoutEnd);
        builder.Ignore(i => i.AccessFailedCount);
        builder.Ignore(i => i.TwoFactorEnabled);
        builder.HasQueryFilter(f => f.IsDeleted == false);
    }
}
