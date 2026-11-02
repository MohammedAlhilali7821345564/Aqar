namespace Aqar.Domain.Vouchers
{
    public partial class Voucher:TraceEntity
    {//السند المالي الرئيسي — يمكن ربطه بعقد أو عقار أو مستأجر أو مورد.
        public int VoucherId { get; set; }

        public string VoucherNumber { get; set; } = null!;

        public byte VoucherTypeId { get; set; }

        public DateOnly VoucherDate { get; set; }

        public int? PropertyId { get; set; }

        public int? ContractId { get; set; }

        public int? TenantId { get; set; }

        public int? SupplierId { get; set; }

        public int? OwnerId { get; set; }

        public byte PaymentMethodId { get; set; }

        public decimal Amount { get; set; }

        public string? ReferenceNumber { get; set; }

        public string? ChequeNumber { get; set; }

        public DateOnly? ChequeDate { get; set; }

        public string? BankName { get; set; }

        public string? Description { get; set; }

        public byte StatusId { get; set; }

        //public DateTime? CancelledAt { get; set; }

        //public int? CancelledBy { get; set; }

        //public string? CancelReason { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public int? CreatedBy { get; set; }

        //public DateTime? UpdatedAt { get; set; }

        //public int? UpdatedBy { get; set; }

        //public virtual User? CancelledByNavigation { get; set; }
        //public virtual User? CreatedByNavigation { get; set; }
        //public virtual User? UpdatedByNavigation { get; set; }



        public virtual Contract? Contract { get; set; }
        public virtual Owner? Owner { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; } = null!;

        public virtual Property? Property { get; set; }

        public virtual ICollection<PropertyExpense> PropertyExpenses { get; set; } = new List<PropertyExpense>();

        public virtual VoucherStatus Status { get; set; } = null!;

        public virtual Supplier? Supplier { get; set; }

        public virtual Tenant? Tenant { get; set; }

        public virtual ICollection<VoucherAllocation> VoucherAllocations { get; set; } = new List<VoucherAllocation>();

        public virtual VoucherType VoucherType { get; set; } = null!;

        public virtual ICollection<WaterPurchase> WaterPurchases { get; set; } = new List<WaterPurchase>();
    }
}