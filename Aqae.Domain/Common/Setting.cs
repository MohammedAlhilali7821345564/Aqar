using Aqar.Domain.Identity;

namespace Aqar.Domain.Common;


public partial class Setting
{
    public byte SettingId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? CompanyPhone { get; set; }

    public string? CompanyAddress { get; set; }

    public short BaseCurrencyId { get; set; }

    public int? DefaultPropertyId { get; set; }

    public short ContractExpiryAlertDays { get; set; }

    public short LateGraceDays { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual Currency BaseCurrency { get; set; } = null!;

    public virtual Property? DefaultProperty { get; set; }

    public virtual User? UpdatedByNavigation { get; set; }
}