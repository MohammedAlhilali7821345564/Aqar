using Aqar.Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Utilities
{
    public class ElectricityUnitMeterConfig : IEntityTypeConfiguration<ElectricityUnitMeter>
    {
        public void Configure(EntityTypeBuilder<ElectricityUnitMeter> entity)
        {
            entity.HasKey(e => e.UnitMeterId).HasName("PK_ElecUnit");

            entity.HasIndex(e => e.UnitId, "UX_ElecUnit_one_active")
                .IsUnique()
                .HasFilter("([is_active]=(1))");

            entity.Property(e => e.UnitMeterId).HasColumnName("unit_meter_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.MeterNumber)
                .HasMaxLength(50)
                .HasColumnName("meter_number");
            entity.Property(e => e.UnitId).HasColumnName("unit_id");

            entity.HasOne(d => d.Unit).WithOne(p => p.ElectricityUnitMeter)
                .HasForeignKey<ElectricityUnitMeter>(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElecUnit_Units");
        }
    }
}