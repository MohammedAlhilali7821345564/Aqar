namespace Aqar.Domain.RealEstate;

public partial class Owner:TraceEntity
{//„«·ﬂ «·⁄ﬁ«— 
    public int OwnerId { get; set; }

    public string OwnerName { get; set; } = null!;

    public string? NationalId { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public bool IsActive { get; set; }

    //public DateTime CreatedAt { get; set; }

    //public DateTime? UpdatedAt { get; set; }

    //public DateTime? DeletedAt { get; set; }

    //public int? DeletedBy { get; set; }

    public virtual User? DeletedByNavigation { get; set; }

    public virtual ICollection<PropertyOwner> PropertyOwners { get; set; } = new List<PropertyOwner>();

    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}
