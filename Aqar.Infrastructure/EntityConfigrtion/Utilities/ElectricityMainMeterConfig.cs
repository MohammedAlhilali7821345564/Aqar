using Aqar.Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Utilities
{
    public class ElectricityMainMeterConfig : IEntityTypeConfiguration<ElectricityMainMeter>
    {
        public void Configure(EntityTypeBuilder<ElectricityMainMeter> entity)
        {
            entity.HasKey(e => e.MainMeterId).HasName("PK_ElecMain");

            entity.HasIndex(e => e.PropertyId, "UX_ElecMain_one_active")
                .IsUnique()
                .HasFilter("([is_active]=(1))");

            entity.Property(e => e.MainMeterId).HasColumnName("main_meter_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.InstallDate).HasColumnName("install_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.MeterNumber)
                .HasMaxLength(50)
                .HasColumnName("meter_number");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");

            entity.HasOne(d => d.Property).WithOne(p => p.ElectricityMainMeter)
                .HasForeignKey<ElectricityMainMeter>(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElecMain_Properties");
        } } 
        }
