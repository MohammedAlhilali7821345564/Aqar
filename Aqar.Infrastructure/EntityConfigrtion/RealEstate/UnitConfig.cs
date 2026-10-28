using Aqar.Domain.RealEstate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.RealEstate
{
    public class UnitConfig : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> entity)
        {

            entity.HasIndex(e => new { e.PropertyId, e.UnitId }, "IX_Units_active").HasFilter("([deleted_at] IS NULL AND [is_active]=(1))");

            entity.HasIndex(e => e.FloorId, "IX_Units_floor");

            entity.HasIndex(e => e.UnitTypeId, "IX_Units_unit_type_id");

            entity.HasIndex(e => new { e.PropertyId, e.UnitNumber }, "UQ_Units_property_number").IsUnique();

            entity.Property(e => e.UnitId).HasColumnName("unit_id");
            entity.Property(e => e.AreaSqm)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("area_sqm");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DefaultRentAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("default_rent_amount");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.FloorId).HasColumnName("floor_id");
            entity.Property(e => e.HasElectricity)
                .HasDefaultValue(true)
                .HasColumnName("has_electricity");
            entity.Property(e => e.HasWater)
                .HasDefaultValue(true)
                .HasColumnName("has_water");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.RoomsCount).HasColumnName("rooms_count");
            entity.Property(e => e.UnitNumber)
                .HasMaxLength(50)
                .HasColumnName("unit_number");
            entity.Property(e => e.UnitTypeId).HasColumnName("unit_type_id");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UnitCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Units_CreatedBy");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.UnitDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK_Units_DeletedBy");

            entity.HasOne(d => d.Property).WithMany(p => p.Units)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Units_Properties");

            entity.HasOne(d => d.UnitType).WithMany(p => p.Units)
                .HasForeignKey(d => d.UnitTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Units_Types");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.UnitUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_Units_UpdatedBy");

            entity.HasOne(d => d.Floor).WithMany(p => p.Units)
                .HasPrincipalKey(p => new { p.PropertyId, p.FloorId })
                .HasForeignKey(d => new { d.PropertyId, d.FloorId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Units_Floor_Property");
        }
    }
}