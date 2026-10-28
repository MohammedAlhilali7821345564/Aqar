using Aqar.Domain.Vouchers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Vouchers
{
    public class VoucherAllocationConfig : IEntityTypeConfiguration<VoucherAllocation>
    {
        public void Configure(EntityTypeBuilder<VoucherAllocation> entity)
        {
            entity.HasKey(e => e.AllocationId);

            entity.HasIndex(e => e.ChargeId, "IX_VA_charge");

            entity.HasIndex(e => new { e.VoucherId, e.ChargeId }, "UQ_VA_voucher_charge").IsUnique();

            entity.Property(e => e.AllocationId).HasColumnName("allocation_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.ChargeId).HasColumnName("charge_id");
            entity.Property(e => e.VoucherId).HasColumnName("voucher_id");

            entity.HasOne(d => d.Charge).WithMany(p => p.VoucherAllocations)
                .HasForeignKey(d => d.ChargeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VA_Charges");

            entity.HasOne(d => d.Voucher).WithMany(p => p.VoucherAllocations)
                .HasForeignKey(d => d.VoucherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VA_Vouchers");
       
        }
}
}
