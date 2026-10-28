
namespace Aqar.Domain.RealEstate
{
    public partial class PropertyOwner
    {//جدول ربط many-to-many بين الملاك والعقارات (share_percent).
        public int PropertyId { get; set; }

        public int OwnerId { get; set; }

        public decimal SharePercent { get; set; }

        public virtual Owner Owner { get; set; } = null!;

        public virtual Property Property { get; set; } = null!;
    }
}