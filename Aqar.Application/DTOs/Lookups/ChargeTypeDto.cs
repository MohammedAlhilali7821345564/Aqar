
namespace Aqar.Application.DTOs.Lookups
{
    public class ChargeTypeDto
    {
        public byte ChargeTypeId { get; set; }

        public string ChargeTypeName { get; set; } = null!;
    }



    public class ChargeTypeEditDto : ChargeTypeDto { }
}
