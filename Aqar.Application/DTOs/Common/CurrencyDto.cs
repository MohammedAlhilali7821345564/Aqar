using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqar.Application.DTOs.Common
{
    public class CurrencyDto
    {
        public short CurrencyId { get; set; }

        public string IsoCode { get; set; } = null!;

        public string CurrencyName { get; set; } = null!;

        public string? Symbol { get; set; }
    }

    public class CurrencyEditDto :CurrencyDto 
    {
    
    
    } 
}
