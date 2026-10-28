
using System.ComponentModel.DataAnnotations;

namespace Aqar.Application.DTOs.Identity
{
    public class SupplierDto
    {
        [Key]
        public int SupplierId { get; set; }
        [StringLength(50)]
        public string SupplierName { get; set; } = null!;
        public string? SupplierCategory { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

    }
    public class SupplierEditDto
    {
        [Key]
        public int SupplierId { get; set; }
        [StringLength(50)]
        public string SupplierName { get; set; } = null!;
        public string? SupplierCategory { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

    }
}
