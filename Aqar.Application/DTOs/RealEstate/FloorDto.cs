using System;
using System.Collections.Generic;

namespace Aqar.Application.DTOs.RealEstate
{
    public class FloorDto
    {
        public int FloorId { get; set; }

        public int PropertyId { get; set; }

        public short FloorNumber { get; set; }

        public string? FloorName { get; set; }
    }
   
    public class FloorEditDto :FloorDto 
    {
    
    
    
    }
}
