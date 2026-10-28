using Aqar.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Identity
{
    public class TenantConfig : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> entity)
        {


            entity.HasIndex(e => e.TenantId, "IX_Tenants_active").HasFilter("([deleted_at] IS NULL AND [is_active]=(1))");

            entity.HasIndex(e => e.TenantName, "IX_Tenants_name");

            entity.HasIndex(e => e.NationalId, "IX_Tenants_national").HasFilter("([national_id] IS NOT NULL)");

            //entity.HasIndex(e => e.TenantCode, "UQ_Tenants_code").IsUnique();

            entity.Property(e => e.TenantId).HasColumnName("tenant_id");
            entity.Property(e => e.Address)
                .HasMaxLength(300)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
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
            entity.Property(e => e.NationalId)
                .HasMaxLength(20)
                .HasColumnName("national_id");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .HasColumnName("notes");
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("phone");
            //entity.Property(e => e.TenantCode)
            //    .HasMaxLength(20)
            //    .IsUnicode(false)
            //    .HasColumnName("tenant_code");
            entity.Property(e => e.TenantName)
                .HasMaxLength(100)
                .HasColumnName("tenant_name");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TenantCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Tenants_CreatedBy");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.TenantDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK_Tenants_DeletedBy");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TenantUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_Tenants_UpdatedBy");
        }
    }
}