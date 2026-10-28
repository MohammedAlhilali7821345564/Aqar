using System;
using System.Collections.Generic;
using System.Linq;

namespace Aqar.Application.DTOs.RealEstate
{
    public class UnitDto
    {
        public int UnitId { get; set; }

        public int PropertyId { get; set; }

        public int FloorId { get; set; }

        public string UnitNumber { get; set; } = null!;

        public byte UnitTypeId { get; set; }

        public decimal? AreaSqm { get; set; }

        public byte? RoomsCount { get; set; }

        public decimal? DefaultRentAmount { get; set; }

    }
    public class UnitEditDto : UnitDto 
    {
    
    
    
    }
}
