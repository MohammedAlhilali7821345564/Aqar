
namespace Aqar.Domain.Lookups;

public partial class ChargeType
{//√‰Ê«⁄ «·–„„ (≈ÌÃ«—/ﬂÂ—»«¡/„«¡/Õ’… „’—Ê›/√Œ—Ï).
    public byte ChargeTypeId { get; set; }

    public string ChargeTypeName { get; set; } = null!;

    public virtual ICollection<ContractCharge> ContractCharges { get; set; } = new List<ContractCharge>();
}
