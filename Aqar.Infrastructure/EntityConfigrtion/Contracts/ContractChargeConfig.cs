using Aqar.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Contracts
{
    public class ContractChargeConfig : IEntityTypeConfiguration<ContractCharge>
    {
        public void Configure(EntityTypeBuilder<ContractCharge> entity)
        {
            entity.HasKey(e => e.ChargeId);

            entity.HasIndex(e => new { e.ContractId, e.DueDate }, "IX_Charges_contract_due");

            entity.HasIndex(e => e.DueDate, "IX_Charges_open_due").HasFilter("([is_cancelled]=(0))");

            entity.HasIndex(e => e.ChargeTypeId, "IX_Charges_type_id");

            entity.HasIndex(e => new { e.ContractId, e.ChargeTypeId, e.PeriodMonth }, "UQ_Charges_open")
                .IsUnique()
                .HasFilter("([period_month] IS NOT NULL AND [is_cancelled]=(0))");

            entity.Property(e => e.ChargeId)
                .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Seq_Charges])")
                .HasColumnName("charge_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.ChargeTypeId).HasColumnName("charge_type_id");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasColumnName("description");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.IsCancelled).HasColumnName("is_cancelled");
            entity.Property(e => e.PeriodMonth).HasColumnName("period_month");

            entity.HasOne(d => d.ChargeType).WithMany(p => p.ContractCharges)
                .HasForeignKey(d => d.ChargeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Charges_Types");

            entity.HasOne(d => d.Contract).WithMany(p => p.ContractCharges)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Charges_Contracts");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ContractCharges)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Charges_CreatedBy");
        }
    }
}
