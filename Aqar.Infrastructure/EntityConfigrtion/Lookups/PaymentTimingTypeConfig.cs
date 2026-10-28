using Aqar.Domain.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Lookups
{
    public class PaymentTimingTypeConfig : IEntityTypeConfiguration<PaymentTimingType>
    {
        public void Configure(EntityTypeBuilder<PaymentTimingType> entity)
        {
            entity.HasKey(e => e.TimingId);

            entity.HasIndex(e => e.TimingName, "UQ_PaymentTimingTypes_name").IsUnique();

            entity.Property(e => e.TimingId).HasColumnName("timing_id");
            entity.Property(e => e.TimingName)
                .HasMaxLength(50)
                .HasColumnName("timing_name");
        }
    }
}