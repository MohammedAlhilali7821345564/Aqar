using Aqar.Domain.RealEstate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.RealEstate
{
    public class PropertyOwnerConfig : IEntityTypeConfiguration<PropertyOwner>

    {
        public void Configure(EntityTypeBuilder<PropertyOwner> entity)
        {
            entity.HasKey(e => new { e.PropertyId, e.OwnerId });

            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.SharePercent)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("share_percent");

            entity.HasOne(d => d.Owner).WithMany(p => p.PropertyOwners)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PO_Owners");

            entity.HasOne(d => d.Property).WithMany(p => p.PropertyOwners)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PO_Properties");
        
        }
    }
}
