
namespace Aqar.Application.DTOs.Common
{
    public class SettingsDto
    {
        public byte SettingId { get; set; }

        public string CompanyName { get; set; } = null!;

        public string? CompanyPhone { get; set; }

        public string? CompanyAddress { get; set; }

        public short BaseCurrencyId { get; set; }

        public int? DefaultPropertyId { get; set; }

        public short ContractExpiryAlertDays { get; set; }

        public short LateGraceDays { get; set; }
    }
    public class SettingsReadDto :SettingsDto 
    {
    
    
    }
}
