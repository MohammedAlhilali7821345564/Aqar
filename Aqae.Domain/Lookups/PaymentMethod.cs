
namespace Aqar.Domain.Lookups;

public partial class PaymentMethod
{//ØÑŞ ÇáÏİÚ (äŞÏÇğ/ÊÍæíá Èäßí/Ôíß).
    public byte PaymentMethodId { get; set; }

    public string PaymentMethodName { get; set; } = null!;

    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}
