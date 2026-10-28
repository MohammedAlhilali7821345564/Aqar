
namespace Aqar.Application.DTOs.Expenses
{
    public class PropertyExpenseDto
    {
        public int ExpenseId { get; set; }

        public int PropertyId { get; set; }
        public short ExpenseTypeId { get; set; }
        public int? SupplierId { get; set; }
        public int? VoucherId { get; set; }
        public DateOnly PeriodMonth { get; set; }
        public DateOnly ExpenseDate { get; set; }
        public decimal Amount { get; set; }
        public byte AllocationMethodId { get; set; }
        public decimal OwnerAmount { get; set; }
    }
   
    public class PropertyExpenseEditDto { }
}
