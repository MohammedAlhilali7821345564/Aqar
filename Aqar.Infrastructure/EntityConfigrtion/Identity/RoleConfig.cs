using Aqar.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Identity
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
    public void Configure(EntityTypeBuilder<Role> entity)
        {
        entity.HasIndex(e => e.RoleName, "UQ_Roles_name").IsUnique();

        entity.Property(e => e.RoleId).HasColumnName("role_id");
        entity.Property(e => e.RoleName)
            .HasMaxLength(50)
            .HasColumnName("role_name");
        }
    }
}