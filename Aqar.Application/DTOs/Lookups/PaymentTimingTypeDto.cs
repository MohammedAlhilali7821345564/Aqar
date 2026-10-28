
namespace Aqar.Application.DTOs.Lookups
{
    public class PaymentTimingTypeDto
    { //مواعيد الدفع (مقدماً في بداية الفترة أو مؤخراً في نهايتها
        public byte TimingId { get; set; }
        public string TimingName { get; set; } = null!;

    }
    public class PaymentTimingTypeEditDto: PaymentTimingTypeDto { }
}
