
using Aqar.Domain.Base;

namespace Aqar.Domain.RealEstate;
// العقار/المبنى والمجمع وربطه بالمالك والطوابق والعدادات
public partial class Property:TraceEntity
{
    public int PropertyId { get; set; }

    public string PropertyCode { get; set; } = null!;

    public string PropertyName { get; set; } = null!;

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    //public DateTime CreatedAt { get; set; }

    //public int? CreatedBy { get; set; }

    //public DateTime? UpdatedAt { get; set; }

    //public int? UpdatedBy { get; set; }

    //public DateTime? DeletedAt { get; set; }

    //public int? DeletedBy { get; set; }

    //public virtual User? CreatedByNavigation { get; set; }

    //public virtual User? DeletedByNavigation { get; set; }
    //public virtual User? UpdatedByNavigation { get; set; }


    public virtual ElectricityMainMeter? ElectricityMainMeter { get; set; }

    public virtual ICollection<Floor> Floors { get; set; } = new List<Floor>();

    public virtual ICollection<PropertyExpense> PropertyExpenses { get; set; } = new List<PropertyExpense>();

    public virtual ICollection<PropertyOwner> PropertyOwners { get; set; } = new List<PropertyOwner>();

    public virtual ICollection<Setting> Settings { get; set; } = new List<Setting>();

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();

    public virtual ICollection<UtilityRate> UtilityRates { get; set; } = new List<UtilityRate>();

    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();

    public virtual ICollection<WaterPurchase> WaterPurchases { get; set; } = new List<WaterPurchase>();
}
