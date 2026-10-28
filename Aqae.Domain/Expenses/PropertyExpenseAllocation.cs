using Aqar.Domain.Contracts;

namespace Aqar.Domain.Expenses
{
    public partial class PropertyExpenseAllocation
    {
        public long AllocationId { get; set; }

        public int ExpenseId { get; set; }

        public int ContractId { get; set; }

        public decimal AllocatedAmount { get; set; }

        public long? ChargeId { get; set; }

        public virtual ContractCharge? Charge { get; set; }

        public virtual Contract Contract { get; set; } = null!;

        public virtual PropertyExpense Expense { get; set; } = null!;
    }
}