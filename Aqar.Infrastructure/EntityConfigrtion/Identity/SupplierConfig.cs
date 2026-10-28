using Aqar.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Identity
{
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> entity)
        {
            entity.HasIndex(e => e.SupplierName, "IX_Suppliers_name");

            //entity.HasIndex(e => e.SupplierCode, "UQ_Suppliers_code").IsUnique();

            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.Address)
                .HasMaxLength(300)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            //entity.Property(e => e.Mobile)
            //    .HasMaxLength(25)
            //    .IsUnicode(false)
            //    .HasColumnName("mobile");
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.SupplierCategory)
                .HasMaxLength(50)
                .HasColumnName("supplier_category");
            //entity.Property(e => e.SupplierCode)
            //    .HasMaxLength(20)
            //    .IsUnicode(false)
            //    .HasColumnName("supplier_code");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(100)
                .HasColumnName("supplier_name");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK_Suppliers_DeletedBy");
        } 
        }
    }
