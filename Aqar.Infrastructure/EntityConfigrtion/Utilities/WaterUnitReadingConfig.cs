using Aqar.Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Utilities
{
    public class WaterUnitReadingConfig : IEntityTypeConfiguration<WaterUnitReading>
    {
        public void Configure(EntityTypeBuilder<WaterUnitReading> entity)
        {
            entity.HasKey(e => e.ReadingId).HasName("PK_WaterUnitRead");

            entity.HasIndex(e => e.PeriodMonth, "IX_WaterUnitRead_period");

            entity.HasIndex(e => new { e.WaterMeterId, e.PeriodMonth }, "UQ_WaterUnitRead").IsUnique();

            entity.Property(e => e.ReadingId).HasColumnName("reading_id");
            entity.Property(e => e.Amount)
                .HasComputedColumnSql("(CONVERT([decimal](18,2),round(([current_reading]-[previous_reading])*isnull([price_per_unit],(0)),(2))))", true)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.ChargeId).HasColumnName("charge_id");
            entity.Property(e => e.Consumption)
                .HasComputedColumnSql("([current_reading]-[previous_reading])", true)
                .HasColumnType("decimal(19, 3)")
                .HasColumnName("consumption");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CurrentReading)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("current_reading");
            entity.Property(e => e.IsOpening).HasColumnName("is_opening");
            entity.Property(e => e.IsOwnerBorne).HasColumnName("is_owner_borne");
            entity.Property(e => e.Notes)
                .HasMaxLength(300)
                .HasColumnName("notes");
            entity.Property(e => e.PeriodMonth).HasColumnName("period_month");
            entity.Property(e => e.PreviousReading)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("previous_reading");
            entity.Property(e => e.PricePerUnit)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("price_per_unit");
            entity.Property(e => e.ReadingDate).HasColumnName("reading_date");
            entity.Property(e => e.WaterMeterId).HasColumnName("water_meter_id");

            entity.HasOne(d => d.Charge).WithMany(p => p.WaterUnitReadings)
                .HasForeignKey(d => d.ChargeId)
                .HasConstraintName("FK_WaterUnitRead_Charges");

            entity.HasOne(d => d.Contract).WithMany(p => p.WaterUnitReadings)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK_WaterUnitRead_Contracts");

            //entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WaterUnitReadings)
            //    .HasForeignKey(d => d.CreatedBy)
            //    .HasConstraintName("FK_WaterUnitRead_CreatedBy");

            entity.HasOne(d => d.WaterMeter).WithMany(p => p.WaterUnitReadings)
                .HasForeignKey(d => d.WaterMeterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WaterUnitRead_Meter");
        
        }
    }
}