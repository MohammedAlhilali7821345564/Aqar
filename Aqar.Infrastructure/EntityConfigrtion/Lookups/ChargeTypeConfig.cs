using Aqar.Domain.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Lookups
{
    public class ChargeTypeConfig : IEntityTypeConfiguration<ChargeType>
    {
        public void Configure(EntityTypeBuilder<ChargeType> entity)
        {
            entity.HasIndex(e => e.ChargeTypeName, "UQ_ChargeTypes_name").IsUnique();

            entity.Property(e => e.ChargeTypeId).HasColumnName("charge_type_id");
            entity.Property(e => e.ChargeTypeName)
                .HasMaxLength(50)
                .HasColumnName("charge_type_name");
        }
    }
}        
      