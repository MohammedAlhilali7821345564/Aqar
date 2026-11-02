using Aqar.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Common
{
    public class SettingConfig : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> entity)
        {
            entity.Property(e => e.SettingId).HasColumnName("setting_id");
            entity.Property(e => e.BaseCurrencyId).HasColumnName("base_currency_id");
            entity.Property(e => e.CompanyAddress)
                .HasMaxLength(300)
                .HasColumnName("company_address");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(150)
                .HasColumnName("company_name");
            entity.Property(e => e.CompanyPhone)
                .HasMaxLength(50)
                .HasColumnName("company_phone");
            entity.Property(e => e.ContractExpiryAlertDays)
                .HasDefaultValue((short)60)
                .HasColumnName("contract_expiry_alert_days");
            entity.Property(e => e.DefaultPropertyId).HasColumnName("default_property_id");
            entity.Property(e => e.LateGraceDays).HasColumnName("late_grace_days");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.BaseCurrency).WithMany(p => p.Settings)
                .HasForeignKey(d => d.BaseCurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Settings_Currency");

            entity.HasOne(d => d.DefaultProperty).WithMany(p => p.Settings)
                .HasForeignKey(d => d.DefaultPropertyId)
                .HasConstraintName("FK_Settings_Property");

            //entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.Settings)
            //    .HasForeignKey(d => d.UpdatedBy)
            //    .HasConstraintName("FK_Settings_UpdatedBy");
        
        }
    }
}
