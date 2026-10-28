using Aqar.Domain.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Aqar.Infrastructure.EntityConfigrtion.Lookups
{
    public class AllocationMethodConfig : IEntityTypeConfiguration<AllocationMethod>
    {
        public void Configure(EntityTypeBuilder<AllocationMethod> entity)
        {
            entity.HasKey(e => e.MethodId);

            entity.HasIndex(e => e.MethodName, "UQ_AllocationMethods_name").IsUnique();

            entity.Property(e => e.MethodId).HasColumnName("method_id");
            entity.Property(e => e.MethodName)
                .HasMaxLength(50)
                .HasColumnName("method_name");
        }
    }
}
