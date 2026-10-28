using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aqar.Application.DTOs.RealEstate
{
    public class OwnerDto
    {
        public int OwnerId { get; set; }

        public string OwnerName { get; set; } = null!;

        public string? NationalId { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
        [StringLength(50)]
        public string? Address { get; set; }
    }

    public class UserEditDto :OwnerDto
    {

    }
}
