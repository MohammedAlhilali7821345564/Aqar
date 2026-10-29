
namespace Aqar.Domain.Vouchers
{
    public partial class VoucherAllocation
    {//تخصيص مبلغ السند على ذمم محددة (علاقة many-to-many بين السندات والذمم
        public long AllocationId { get; set; }

        public int VoucherId { get; set; }

        public long ChargeId { get; set; }

        public decimal Amount { get; set; }

        public virtual ContractCharge Charge { get; set; } = null!;

        public virtual Voucher Voucher { get; set; } = null!;
    }
}