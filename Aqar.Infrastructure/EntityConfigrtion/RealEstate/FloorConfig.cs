using Aqar.Domain.RealEstate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Aqar.Infrastructure.EntityConfigrtion.RealEstate
{
    public class FloorConfig : IEntityTypeConfiguration<Floor>
    {
        public void Configure(EntityTypeBuilder<Floor> entity)
        {
            entity.HasIndex(e => new { e.PropertyId, e.FloorId }, "UQ_Floors_property_floorid").IsUnique();

            entity.HasIndex(e => new { e.PropertyId, e.FloorNumber }, "UQ_Floors_property_number").IsUnique();

            entity.Property(e => e.FloorId).HasColumnName("floor_id");
            entity.Property(e => e.FloorName)
                .HasMaxLength(50)
                .HasColumnName("floor_name");
            entity.Property(e => e.FloorNumber).HasColumnName("floor_number");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");

            entity.HasOne(d => d.Property).WithMany(p => p.Floors)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Floors_Properties");
        }
    }
}


