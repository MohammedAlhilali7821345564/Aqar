using Aqar.Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Aqar.Infrastructure.EntityConfigrtion.Utilities
{
    public class ElectricityMainMeterReadingConfig : IEntityTypeConfiguration<ElectricityMainMeterReading>
    {
        public void Configure(EntityTypeBuilder<ElectricityMainMeterReading> entity)
        {
            entity.HasKey(e => e.MainReadingId).HasName("PK_ElecMainRead");

            entity.HasIndex(e => new { e.MainMeterId, e.PeriodMonth }, "UQ_ElecMainRead").IsUnique();

            entity.Property(e => e.MainReadingId).HasColumnName("main_reading_id");
            entity.Property(e => e.BillAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("bill_amount");
            entity.Property(e => e.Consumption)
                .HasComputedColumnSql("([current_reading]-[previous_reading])", true)
                .HasColumnType("decimal(19, 3)")
                .HasColumnName("consumption");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CurrentReading)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("current_reading");
            entity.Property(e => e.IsOpening).HasColumnName("is_opening");
            entity.Property(e => e.MainMeterId).HasColumnName("main_meter_id");
            entity.Property(e => e.Notes)
                .HasMaxLength(300)
                .HasColumnName("notes");
            entity.Property(e => e.PeriodMonth).HasColumnName("period_month");
            entity.Property(e => e.PreviousReading)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("previous_reading");
            entity.Property(e => e.ReadingDate).HasColumnName("reading_date");

            //entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ElectricityMainMeterReadings)
            //    .HasForeignKey(d => d.CreatedBy)
            //    .HasConstraintName("FK_ElecMainRead_CreatedBy");

            entity.HasOne(d => d.MainMeter).WithMany(p => p.ElectricityMainMeterReadings)
                .HasForeignKey(d => d.MainMeterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElecMainRead_Meter");
        }
    }
}
