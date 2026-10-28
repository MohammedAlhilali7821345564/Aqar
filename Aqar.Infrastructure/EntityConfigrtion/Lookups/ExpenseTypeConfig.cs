using Aqar.Domain.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Lookups
{
    public class ExpenseTypeConfig : IEntityTypeConfiguration<ExpenseType>
    {
      public void Configure(EntityTypeBuilder<ExpenseType> entity)
        {
        entity.HasIndex(e => e.ExpenseTypeName, "UQ_ExpenseTypes_name").IsUnique();

        entity.Property(e => e.ExpenseTypeId).HasColumnName("expense_type_id");
        entity.Property(e => e.DefaultAllocationMethodId).HasColumnName("default_allocation_method_id");
        entity.Property(e => e.ExpenseTypeName)
            .HasMaxLength(100)
            .HasColumnName("expense_type_name");
        entity.Property(e => e.IsActive)
            .HasDefaultValue(true)
            .HasColumnName("is_active");

        entity.HasOne(d => d.DefaultAllocationMethod).WithMany(p => p.ExpenseTypes)
            .HasForeignKey(d => d.DefaultAllocationMethodId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ExpenseTypes_Method");
        }
    }
}