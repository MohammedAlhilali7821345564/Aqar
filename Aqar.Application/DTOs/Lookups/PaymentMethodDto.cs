
namespace Aqar.Application.DTOs.Lookups
{
    public class PaymentMethodDto
    {//طرق الدفع (نقداً/تحويل بنكي/شيك).
        public byte PaymentMethodId { get; set; }

        public string PaymentMethodName { get; set; } = null!;

    }
    public class PaymentMethodEditDto : PaymentMethodDto { }
}
