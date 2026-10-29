
namespace Aqar.Domain.Lookups;

public partial class ContractStatus
{//ÍÇáÇÊ ÇáÚŞÏ (äÔØ/ãäÊåí/ãİÓæÎ/ãÓæÏÉ).
    public byte StatusId { get; set; }
    public string StatusName { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
