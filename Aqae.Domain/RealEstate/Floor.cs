
namespace Aqar.Domain.RealEstate;

public partial class Floor
{//ØæÇÈÞ ÇáÚÞÇÑ — composite unique Úáì (property_id + floor_number + floor_id).
    public int FloorId { get; set; }

    public int PropertyId { get; set; }

    public short FloorNumber { get; set; }

    public string? FloorName { get; set; }

    public bool IsActive { get; set; }

    public virtual Property Property { get; set; } = null!;

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
}
