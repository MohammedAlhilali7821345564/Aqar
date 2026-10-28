
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Aqar.Application.DTOs.RealEstate
{
    public class PropertyDto
    {
        public int PropertyId { get; set; }

        public string PropertyCode { get; set; } = null!;

        public string PropertyName { get; set; } = null!;

        public string? Address { get; set; }

        public string? City { get; set; }
        [StringLength(50)]
        public string? Description { get; set; }
    }
    public class PropertyEditDto: PropertyDto { }
}
