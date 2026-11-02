using Aqar.Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Utilities
{
    public class ElectricityUnitReadingConfig : IEntityTypeConfiguration<ElectricityUnitReading>
    {
        public void Configure(EntityTypeBuilder<ElectricityUnitReading> entity)
        {
            entity.HasKey(e => e.ReadingId).HasName("PK_ElecUnitRead");

            entity.HasIndex(e => e.PeriodMonth, "IX_ElecUnitRead_period");

            entity.HasIndex(e => new { e.UnitMeterId, e.PeriodMonth }, "UQ_ElecUnitRead").IsUnique();

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
            entity.Property(e => e.UnitMeterId).HasColumnName("unit_meter_id");

            entity.HasOne(d => d.Charge).WithMany(p => p.ElectricityUnitReadings)
                .HasForeignKey(d => d.ChargeId)
                .HasConstraintName("FK_ElecUnitRead_Charges");

            entity.HasOne(d => d.Contract).WithMany(p => p.ElectricityUnitReadings)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK_ElecUnitRead_Contracts");

            //entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ElectricityUnitReadings)
            //    .HasForeignKey(d => d.CreatedBy)
            //    .HasConstraintName("FK_ElecUnitRead_CreatedBy");

            entity.HasOne(d => d.UnitMeter).WithMany(p => p.ElectricityUnitReadings)
                .HasForeignKey(d => d.UnitMeterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElecUnitRead_Meter");
        }
    }
}