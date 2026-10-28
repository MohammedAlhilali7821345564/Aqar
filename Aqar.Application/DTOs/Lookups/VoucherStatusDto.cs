
namespace Aqar.Application.DTOs.Lookups
{
    public class VoucherStatusDto
    {
        //حالة السند (معتمد/ملغي).
        public byte StatusId { get; set; }

        public string StatusName { get; set; } = null!;

    }
    public class VoucherStatusEditDto { }
}
