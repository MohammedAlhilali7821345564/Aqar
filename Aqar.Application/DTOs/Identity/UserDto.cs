using Aqar.Domain.Identity;
using System;
using System.Collections.Generic;

namespace Aqar.Application.DTOs.Identity
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public byte RoleId { get; set; }

        public string PasswordHash { get; set; } = null!;
    }

    public class UserEditDto :UserDto 
    { 
    

    
    }
}
