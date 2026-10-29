

namespace Aqar.Domain.Lookups
{
    public partial class VoucherType
    {// نوع السند (سند قبض RECEIPT / سند صرف PAYMENT) — مع بادئة توليد الرقم
        public byte VoucherTypeId { get; set; }

        public string VoucherTypeCode { get; set; } = null!;

        public string VoucherTypeName { get; set; } = null!;

        public string NumberPrefix { get; set; } = null!;

        public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
    }
}