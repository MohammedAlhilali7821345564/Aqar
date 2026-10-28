namespace Aqar.Domain.Utilities;

public partial class WaterPurchase
{//فاتورة شراء مياه للعقار (من مورد) — بكمية ومبلغ وترتبط بسند.
    public int PurchaseId { get; set; }

    public int PropertyId { get; set; }

    public int? SupplierId { get; set; }

    public int? VoucherId { get; set; }

    public DateOnly PurchaseDate { get; set; }

    public DateOnly PeriodMonth { get; set; }

    public decimal? Quantity { get; set; }

    public decimal Amount { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual Property Property { get; set; } = null!;

    public virtual Supplier? Supplier { get; set; }

    public virtual Voucher? Voucher { get; set; }
}
