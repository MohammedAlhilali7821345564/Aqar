using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aqar.Application.DTOs.Identity
{
    public record TenantCreateDto
    {
        public int TenantId { get; set; }
        [StringLength(100)]
        public string? TenantName { get; init; }
        public string? NationalId { get; init; }
        [Phone]
        public string? Phone { get; init; }
        [EmailAddress]
        public string? Email { get; init; }
        [StringLength(20)]
        public string? Address { get; init; }
        [StringLength(90)]
        public string? Notes { get; init; }
    }
    public record TenantUpdateDto
    {
        public int TenantId { get; set; }
        [StringLength(100)]
        public string? TenantName { get; init; }
        public string? NationalId { get; init; }
        [Phone] 
        public string? Phone { get; init; }
        [EmailAddress] 
        public string? Email { get; init; }
        [StringLength(20)] 
        public string? Address { get; init; }
        [StringLength(90)] 
        public string? Notes { get; init; }
    }

}
