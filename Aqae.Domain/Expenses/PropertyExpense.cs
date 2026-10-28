
namespace Aqar.Domain.Expenses;

// فواتير ومصروفات العقار (صيانة، تشغيل، نظافة)

public partial class PropertyExpense
{
    public int ExpenseId { get; set; }

    public int PropertyId { get; set; }

    public short ExpenseTypeId { get; set; }

    public int? SupplierId { get; set; }

    public int? VoucherId { get; set; }

    public DateOnly PeriodMonth { get; set; }

    public DateOnly ExpenseDate { get; set; }

    public decimal Amount { get; set; }

    public byte AllocationMethodId { get; set; }

    public decimal OwnerAmount { get; set; }

    public string? Description { get; set; }

    public bool IsCancelled { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual AllocationMethod AllocationMethod { get; set; } = null!;

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ExpenseType ExpenseType { get; set; } = null!;

    public virtual Property Property { get; set; } = null!;

    public virtual ICollection<PropertyExpenseAllocation> PropertyExpenseAllocations { get; set; } = new List<PropertyExpenseAllocation>();

    public virtual Supplier? Supplier { get; set; }

    public virtual User? UpdatedByNavigation { get; set; }

    public virtual Voucher? Voucher { get; set; }
}
