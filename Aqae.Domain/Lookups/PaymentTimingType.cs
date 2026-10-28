
using Aqar.Domain.Contracts;

namespace Aqar.Domain.Lookups;

public partial class PaymentTimingType
{//ãæÇÚíÏ ÇáÏİÚ (ãŞÏãÇğ İí ÈÏÇíÉ ÇáİÊÑÉ Ãæ ãÄÎÑÇğ İí äåÇíÊåÇ
    public byte TimingId { get; set; }

    public string TimingName { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
