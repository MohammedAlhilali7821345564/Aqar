using Aqar.Domain.Vouchers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Vouchers
{
    public class VoucherConfig : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> entity)
        {
            entity.HasIndex(e => e.ContractId, "IX_Vouchers_contract");

            entity.HasIndex(e => new { e.VoucherDate, e.VoucherTypeId }, "IX_Vouchers_date");

            entity.HasIndex(e => e.PaymentMethodId, "IX_Vouchers_method_id");

            entity.HasIndex(e => new { e.PropertyId, e.VoucherDate }, "IX_Vouchers_property");

            entity.HasIndex(e => e.StatusId, "IX_Vouchers_status_id");

            entity.HasIndex(e => e.TenantId, "IX_Vouchers_tenant").HasFilter("([tenant_id] IS NOT NULL)");

            entity.HasIndex(e => e.VoucherTypeId, "IX_Vouchers_type_id");

            entity.HasIndex(e => e.VoucherNumber, "UQ_Vouchers_number").IsUnique();

            entity.Property(e => e.VoucherId)
                .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Seq_Vouchers])")
                .HasColumnName("voucher_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.BankName)
                .HasMaxLength(100)
                .HasColumnName("bank_name");
            //entity.Property(e => e.CancelReason)
            //    .HasMaxLength(300)
            //    .HasColumnName("cancel_reason");
            //entity.Property(e => e.CancelledAt)
            //    .HasPrecision(0)
            //    .HasColumnName("cancelled_at");
            //entity.Property(e => e.CancelledBy).HasColumnName("cancelled_by");
            entity.Property(e => e.ChequeDate).HasColumnName("cheque_date");
            entity.Property(e => e.ChequeNumber)
                .HasMaxLength(50)
                .HasColumnName("cheque_number");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(50)
                .HasColumnName("reference_number");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.TenantId).HasColumnName("tenant_id");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.VoucherDate).HasColumnName("voucher_date");
            entity.Property(e => e.VoucherNumber)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("voucher_number");
            entity.Property(e => e.VoucherTypeId).HasColumnName("voucher_type_id");

            //entity.HasOne(d => d.CancelledByNavigation).WithMany(p => p.VoucherCancelledByNavigations)
            //    .HasForeignKey(d => d.CancelledBy)
            //    .HasConstraintName("FK_Vouchers_CancelledBy");

            //entity.HasOne(d => d.Contract).WithMany(p => p.Vouchers)
            //    .HasForeignKey(d => d.ContractId)
            //    .HasConstraintName("FK_Vouchers_Contracts");

            //entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.VoucherCreatedByNavigations)
            //    .HasForeignKey(d => d.CreatedBy)
            //    .HasConstraintName("FK_Vouchers_CreatedBy");

            entity.HasOne(d => d.Owner).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK_Vouchers_Owners");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vouchers_Method");

            entity.HasOne(d => d.Property).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.PropertyId)
                .HasConstraintName("FK_Vouchers_Properties");

            entity.HasOne(d => d.Status).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vouchers_Status");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Vouchers_Suppliers");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.TenantId)
                .HasConstraintName("FK_Vouchers_Tenants");

            //entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.VoucherUpdatedByNavigations)
            //    .HasForeignKey(d => d.UpdatedBy)
            //    .HasConstraintName("FK_Vouchers_UpdatedBy");

            entity.HasOne(d => d.VoucherType).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.VoucherTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vouchers_Types");
        } } }
        