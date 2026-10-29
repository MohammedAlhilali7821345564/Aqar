using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqar.Application.DTOs.Vouchers
{
    public class VoucherDto
    {
        public int VoucherId { get; set; }

        public string VoucherNumber { get; set; } = null!;

        public byte VoucherTypeId { get; set; }

        public DateOnly VoucherDate { get; set; }

        public int? PropertyId { get; set; }

        public int? ContractId { get; set; }

        public int? TenantId { get; set; }

        public int? SupplierId { get; set; }

        public int? OwnerId { get; set; }

        public byte PaymentMethodId { get; set; }

        public decimal Amount { get; set; }

        public string? ReferenceNumber { get; set; }

        public string? ChequeNumber { get; set; }

        public DateOnly? ChequeDate { get; set; }

        public string? BankName { get; set; }

        public string? Description { get; set; }
    }
}
