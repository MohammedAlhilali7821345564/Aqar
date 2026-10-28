using Aqar.Domain.Expenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Expenses
{
    public class PropertyExpenseAllocationConfig : IEntityTypeConfiguration<PropertyExpenseAllocation>
    {
        public void Configure(EntityTypeBuilder<PropertyExpenseAllocation> entity)
        {
            entity.HasKey(e => e.AllocationId).HasName("PK_PEA");

            entity.HasIndex(e => new { e.ExpenseId, e.ContractId }, "UQ_PEA_expense_contract").IsUnique();

            entity.Property(e => e.AllocationId).HasColumnName("allocation_id");
            entity.Property(e => e.AllocatedAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("allocated_amount");
            entity.Property(e => e.ChargeId).HasColumnName("charge_id");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.ExpenseId).HasColumnName("expense_id");

            entity.HasOne(d => d.Charge).WithMany(p => p.PropertyExpenseAllocations)
                .HasForeignKey(d => d.ChargeId)
                .HasConstraintName("FK_PEA_Charges");

            entity.HasOne(d => d.Contract).WithMany(p => p.PropertyExpenseAllocations)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PEA_Contracts");

            entity.HasOne(d => d.Expense).WithMany(p => p.PropertyExpenseAllocations)
                .HasForeignKey(d => d.ExpenseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PEA_Expenses");
        }
    }
}