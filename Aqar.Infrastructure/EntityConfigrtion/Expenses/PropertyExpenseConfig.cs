using Aqar.Domain.Expenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Expenses
{
    public class PropertyExpenseConfig : IEntityTypeConfiguration<PropertyExpense>
    {
        public void Configure(EntityTypeBuilder<PropertyExpense> entity)
        {
            entity.HasKey(e => e.ExpenseId);

            entity.HasIndex(e => new { e.PropertyId, e.PeriodMonth }, "IX_PE_property_month");

            entity.HasIndex(e => e.SupplierId, "IX_PE_supplier_id");

            entity.HasIndex(e => e.ExpenseTypeId, "IX_PE_type_id");

            entity.HasIndex(e => new { e.ExpenseTypeId, e.PeriodMonth }, "IX_PE_type_month");

            entity.Property(e => e.ExpenseId).HasColumnName("expense_id");
            entity.Property(e => e.AllocationMethodId).HasColumnName("allocation_method_id");
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
            entity.Property(e => e.ExpenseDate).HasColumnName("expense_date");
            entity.Property(e => e.ExpenseTypeId).HasColumnName("expense_type_id");
            entity.Property(e => e.IsCancelled).HasColumnName("is_cancelled");
            entity.Property(e => e.OwnerAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("owner_amount");
            entity.Property(e => e.PeriodMonth).HasColumnName("period_month");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.VoucherId).HasColumnName("voucher_id");

            entity.HasOne(d => d.AllocationMethod).WithMany(p => p.PropertyExpenses)
                .HasForeignKey(d => d.AllocationMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PE_Method");

            //entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PropertyExpenseCreatedByNavigations)
            //    .HasForeignKey(d => d.CreatedBy)
            //    .HasConstraintName("FK_PE_CreatedBy");

            entity.HasOne(d => d.ExpenseType).WithMany(p => p.PropertyExpenses)
                .HasForeignKey(d => d.ExpenseTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PE_Types");

            entity.HasOne(d => d.Property).WithMany(p => p.PropertyExpenses)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PE_Properties");

            entity.HasOne(d => d.Supplier).WithMany(p => p.PropertyExpenses)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_PE_Suppliers");

            //entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.PropertyExpenseUpdatedByNavigations)
            //    .HasForeignKey(d => d.UpdatedBy)
            //    .HasConstraintName("FK_PE_UpdatedBy");

            entity.HasOne(d => d.Voucher).WithMany(p => p.PropertyExpenses)
                .HasForeignKey(d => d.VoucherId)
                .HasConstraintName("FK_PE_Vouchers");
        }
    }
}
