namespace Aqar.Domain.Lookups;

public partial class UnitType
{//ÃäæÇÚ ÇáæÍÏÇÊ (ÔŞÉ/ãÍá/ãßÊÈ/ãÓÊæÏÚ/ÛÑİÉ/İíáÇ).
    public byte UnitTypeId { get; set; }

    public string UnitTypeName { get; set; } = null!;

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
}
