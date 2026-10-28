using Aqar.Domain.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Lookups
{
    public class UnitTypeConfig : IEntityTypeConfiguration<UnitType>
    {
        public void Configure(EntityTypeBuilder<UnitType> entity)
        {

    entity.HasIndex(e => e.UnitTypeName, "UQ_UnitTypes_name").IsUnique();

    entity.Property(e => e.UnitTypeId).HasColumnName("unit_type_id");
    entity.Property(e => e.UnitTypeName)
        .HasMaxLength(50)
        .HasColumnName("unit_type_name");
        }
    }
}