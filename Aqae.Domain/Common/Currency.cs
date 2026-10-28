
namespace Aqar.Domain.Common;

public partial class Currency
{//العملات
    public short CurrencyId { get; set; }

    public string IsoCode { get; set; } = null!;

    public string CurrencyName { get; set; } = null!;

    public string? Symbol { get; set; }

    public byte Decimals { get; set; }

    public virtual ICollection<Setting> Settings { get; set; } = new List<Setting>();
}