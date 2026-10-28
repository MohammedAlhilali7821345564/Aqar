using Aqar.Domain.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqar.Infrastructure.EntityConfigrtion.Lookups
{
    public class ContractStatusConfig : IEntityTypeConfiguration<ContractStatus>
    {
        public void Configure(EntityTypeBuilder<ContractStatus> entity)
        {
            entity.HasKey(e => e.StatusId);

            entity.HasIndex(e => e.StatusName, "UQ_ContractStatuses_name").IsUnique();

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.StatusName).HasMaxLength(50)
                .HasColumnName("status_name");
        }
    }
}