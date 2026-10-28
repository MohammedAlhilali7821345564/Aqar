using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqar.Application.DTOs.Lookups
{
    public class AllocationMethodDto
    {
        public byte MethodId { get; set; }

        public string MethodName { get; set; } = null!;
    }
    public class AllocationMethodEditDto : AllocationMethodDto { }
}
