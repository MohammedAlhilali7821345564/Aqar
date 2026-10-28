using Aqar.Domain.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Lookups
{
    public class VoucherTypeConfig : IEntityTypeConfiguration<VoucherType>
    {
        public void Configure(EntityTypeBuilder<VoucherType> entity)
        {
            entity.HasIndex(e => e.VoucherTypeCode, "UQ_VoucherTypes_code").IsUnique();

            entity.Property(e => e.VoucherTypeId).HasColumnName("voucher_type_id");
            entity.Property(e => e.NumberPrefix)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("number_prefix");
            entity.Property(e => e.VoucherTypeCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("voucher_type_code");
            entity.Property(e => e.VoucherTypeName)
                .HasMaxLength(50)
                .HasColumnName("voucher_type_name");
        
        }
    }
}
