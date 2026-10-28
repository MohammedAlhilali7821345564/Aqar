
namespace Aqar.Application.DTOs.Contracts
{
    public class ContractChargeDto
    {
        public long ChargeId { get; set; }
        public int ContractId { get; set; }
        public byte ChargeTypeId { get; set; }
        public DateOnly? PeriodMonth { get; set; }
        public DateOnly DueDate { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public bool IsCancelled { get; set; }
    }
    public class ContractChargeEditDto() { }
}
