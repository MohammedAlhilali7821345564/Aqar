using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqar.Application.DTOs.Contracts
{
    public class ContractDto
    {
        public int ContractId { get; set; }
        public string ContractNumber { get; set; } = null!;
        public int UnitId { get; set; }
        public int TenantId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public DateOnly? RentStartDate { get; set; }
        public decimal MonthlyRent { get; set; }
        public byte PaymentFrequencyMonths { get; set; }
        public byte PaymentTimingId { get; set; }
        public byte AdvanceMonths { get; set; }
        public byte StatusId { get; set; }

    }

    public class ContractEditDto : ContractDto 
    {
    
    
    }
}
