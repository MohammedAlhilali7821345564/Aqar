using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqar.Application.DTOs.Expenses
{
    public class PropertyExpenseAllocationDto
    {
        public long AllocationId { get; set; }

        public int ExpenseId { get; set; }
        public int ContractId { get; set; }
        public decimal AllocatedAmount { get; set; }
        public long? ChargeId { get; set; }
    }

    public class PropertyExpenseAllocationEditDto:PropertyExpenseAllocationDto { }
}
