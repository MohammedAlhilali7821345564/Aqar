using Aqar.Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Utilities
{
    public class WaterPurchaseConfig : IEntityTypeConfiguration<WaterPurchase>
    {
        public void Configure(EntityTypeBuilder<WaterPurchase> entity)
        {
            entity.HasKey(e => e.PurchaseId);

            entity.HasIndex(e => new { e.PropertyId, e.PeriodMonth }, "IX_WP_property_month");

            entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasColumnName("description");
            entity.Property(e => e.PeriodMonth).HasColumnName("period_month");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_date");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("quantity");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.VoucherId).HasColumnName("voucher_id");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WaterPurchases)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_WP_CreatedBy");

            entity.HasOne(d => d.Property).WithMany(p => p.WaterPurchases)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WP_Properties");

            entity.HasOne(d => d.Supplier).WithMany(p => p.WaterPurchases)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_WP_Suppliers");

            entity.HasOne(d => d.Voucher).WithMany(p => p.WaterPurchases)
                .HasForeignKey(d => d.VoucherId)
                .HasConstraintName("FK_WP_Vouchers");
     }
    }
}
