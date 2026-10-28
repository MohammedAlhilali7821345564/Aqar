namespace Aqar.Domain.Identity;

public partial class Tenant:TraceEntity
{// المستأجر — بياناته الكاملة + soft delete.
    public int TenantId { get; set; }

    public string TenantName { get; set; } = null!;

    public string? NationalId { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Notes { get; set; }

    public bool IsActive { get; set; }

    //public DateTime CreatedAt { get; set; }

    //public int? CreatedBy { get; set; }

    //public DateTime? UpdatedAt { get; set; }

    //public int? UpdatedBy { get; set; }

    //public DateTime? DeletedAt { get; set; }

    //public int? DeletedBy { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? DeletedByNavigation { get; set; }

    public virtual User? UpdatedByNavigation { get; set; }

    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}