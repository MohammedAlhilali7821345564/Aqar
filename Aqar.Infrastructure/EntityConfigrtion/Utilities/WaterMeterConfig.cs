using Aqar.Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Utilities
{
    public class WaterMeterConfig : IEntityTypeConfiguration<WaterMeter>
    {
        public void Configure(EntityTypeBuilder<WaterMeter> entity)
        {
        entity.HasIndex(e => e.UnitId, "UX_WaterMeters_one_active")
                .IsUnique()
                .HasFilter("([is_active]=(1))");

        entity.Property(e => e.WaterMeterId).HasColumnName("water_meter_id");
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

        entity.HasOne(d => d.Unit).WithOne(p => p.WaterMeter)
            .HasForeignKey<WaterMeter>(d => d.UnitId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_WaterMeters_Units");
    }
}
}