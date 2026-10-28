
using System.ComponentModel.DataAnnotations;

namespace Aqar.Application.DTOs.Identity
{
    public class RoleDto
    {
        [Key]
        public byte RoleId { get; set; }
        [StringLength(20)]
        public string RoleName { get; set; } = null!;
    }
    public class RoleEditDto
    {
        [Key]

        public byte RoleId { get; set; }
        [StringLength(20)]
        public string RoleName { get; set; } = null!;
    }
}
