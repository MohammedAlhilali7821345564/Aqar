
namespace Aqar.Application.DTOs.Lookups
{
    public class UnitTypeDto
    { //أنواع الوحدات (شقة/محل/مكتب/مستودع/غرفة/فيلا).
        public byte UnitTypeId { get; set; }

        public string UnitTypeName { get; set; } = null!;
    }
    public class UnitTypeEditDto : UnitTypeDto { }
}
