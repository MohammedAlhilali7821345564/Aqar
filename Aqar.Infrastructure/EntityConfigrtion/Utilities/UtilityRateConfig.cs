using Aqar.Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Utilities
{
    public class UtilityRateConfig : IEntityTypeConfiguration<UtilityRate>
    {
        public void Configure(EntityTypeBuilder<UtilityRate> entity)
        {
            entity.HasKey(e => e.RateId);

            entity.HasIndex(e => new { e.PropertyId, e.UtilityType, e.EffectiveFrom }, "UQ_UR").IsUnique();

            entity.Property(e => e.RateId).HasColumnName("rate_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.EffectiveFrom).HasColumnName("effective_from");
            entity.Property(e => e.PricePerUnit)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("price_per_unit");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.UtilityType).HasColumnName("utility_type");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UtilityRates)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_UR_CreatedBy");

            entity.HasOne(d => d.Property).WithMany(p => p.UtilityRates)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UR_Properties");
        }
    }
}
