using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqar.Application.DTOs.Lookups
{
    public class VoucherTypeDto
    {
        public byte VoucherTypeId { get; set; }

        public string VoucherTypeCode { get; set; } = null!;

        public string VoucherTypeName { get; set; } = null!;
        public string NumberPrefix { get; set; } = null!;
    }
}
