using Aqar.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Contracts
{
    public class ContractConfig : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> entity)
        {
            entity.HasIndex(e => new { e.StatusId, e.EndDate }, "IX_Contracts_status");

            entity.HasIndex(e => e.StatusId, "IX_Contracts_status_id");

            entity.HasIndex(e => e.TenantId, "IX_Contracts_tenant");

            entity.HasIndex(e => e.UnitId, "IX_Contracts_unit");

            entity.HasIndex(e => e.ContractNumber, "UQ_Contracts_number").IsUnique();

            entity.Property(e => e.ContractId)
                .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Seq_Contracts])")
                .HasColumnName("contract_id");
            entity.Property(e => e.AdvanceAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("advance_amount");
            entity.Property(e => e.AdvanceMonths).HasColumnName("advance_months");
            entity.Property(e => e.AdvanceMonthsConsumed).HasColumnName("advance_months_consumed");
            entity.Property(e => e.ContractNumber)
                .HasMaxLength(50)
                .HasColumnName("contract_number");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DepositAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("deposit_amount");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.MonthlyRent)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("monthly_rent");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .HasColumnName("notes");
            entity.Property(e => e.PaymentFrequencyMonths)
                .HasDefaultValue((byte)1)
                .HasColumnName("payment_frequency_months");
            entity.Property(e => e.PaymentTimingId).HasColumnName("payment_timing_id");
            entity.Property(e => e.RentStartDate).HasColumnName("rent_start_date");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TenantId).HasColumnName("tenant_id");
            entity.Property(e => e.TerminatedDate).HasColumnName("terminated_date");
            entity.Property(e => e.TerminationReason)
                .HasMaxLength(300)
                .HasColumnName("termination_reason");
            entity.Property(e => e.UnitId).HasColumnName("unit_id");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ContractCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Contracts_CreatedBy");

            entity.HasOne(d => d.PaymentTiming).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.PaymentTimingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contracts_Timing");

            entity.HasOne(d => d.Status).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contracts_Status");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contracts_Tenants");

            entity.HasOne(d => d.Unit).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contracts_Units");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ContractUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_Contracts_UpdatedBy");
        }
    }
}   