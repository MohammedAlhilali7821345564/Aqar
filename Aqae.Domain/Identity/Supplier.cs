namespace Aqar.Domain.Identity;


public partial class Supplier
{//موردو الخدمات (صيانة/كهرباء/مياه
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string? SupplierCategory { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual User? DeletedByNavigation { get; set; }

    public virtual ICollection<PropertyExpense> PropertyExpenses { get; set; } = new List<PropertyExpense>();

    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();

    public virtual ICollection<WaterPurchase> WaterPurchases { get; set; } = new List<WaterPurchase>();
}