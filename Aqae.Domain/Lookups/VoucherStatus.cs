
namespace Aqar.Domain.Lookups
{
    public partial class VoucherStatus
    {//حالة السند (معتمد/ملغي).
        public byte StatusId { get; set; }

        public string StatusName { get; set; } = null!;

        public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
    }
}