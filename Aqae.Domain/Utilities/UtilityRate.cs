using Aqar.Domain.Identity;

namespace Aqar.Domain.Utilities;

public partial class UtilityRate
{// أسعار الوحدة (كيلو واط/متر مكعب) لكل عقار مع تاريخ سريان. نوعان: 1=كهرباء، 2=ماء.

    public int RateId { get; set; }

    public int PropertyId { get; set; }

    public byte UtilityType { get; set; }

    public decimal PricePerUnit { get; set; }

    public DateOnly EffectiveFrom { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual Property Property { get; set; } = null!;
    }
