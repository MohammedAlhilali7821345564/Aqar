using Aqar.Domain.RealEstate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.RealEstate
{
    public class PropertyConfig : IEntityTypeConfiguration<Property>
    {
     public void Configure(EntityTypeBuilder<Property> entity)
        {
        entity.HasIndex(e => e.PropertyName, "IX_Properties_name");

        entity.HasIndex(e => e.PropertyCode, "UQ_Properties_code").IsUnique();

        entity.Property(e => e.PropertyId).HasColumnName("property_id");
        entity.Property(e => e.Address)
            .HasMaxLength(300)
            .HasColumnName("address");
        entity.Property(e => e.City)
            .HasMaxLength(50)
            .HasColumnName("city");
        entity.Property(e => e.CreatedAt)
            .HasPrecision(0)
            .HasDefaultValueSql("(sysutcdatetime())")
            .HasColumnName("created_at");
        entity.Property(e => e.CreatedBy).HasColumnName("created_by");
        entity.Property(e => e.DeletedAt)
            .HasPrecision(0)
            .HasColumnName("deleted_at");
        entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
        entity.Property(e => e.Description)
            .HasMaxLength(500)
            .HasColumnName("description");
        entity.Property(e => e.IsActive)
            .HasDefaultValue(true)
            .HasColumnName("is_active");
        entity.Property(e => e.PropertyCode)
            .HasMaxLength(50)
            .HasColumnName("property_code");
        entity.Property(e => e.PropertyName)
            .HasMaxLength(150)
            .HasColumnName("property_name");
        entity.Property(e => e.UpdatedAt)
            .HasPrecision(0)
            .HasColumnName("updated_at");
        entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

        entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PropertyCreatedByNavigations)
            .HasForeignKey(d => d.CreatedBy)
            .HasConstraintName("FK_Properties_CreatedBy");

        entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.PropertyDeletedByNavigations)
            .HasForeignKey(d => d.DeletedBy)
            .HasConstraintName("FK_Properties_DeletedBy");

        entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.PropertyUpdatedByNavigations)
            .HasForeignKey(d => d.UpdatedBy)
            .HasConstraintName("FK_Properties_UpdatedBy");
        }
    }
}
