
namespace Aqar.Application.DTOs.Lookups
{
    public class ContractStatusDto
    {
        public byte StatusId { get; set; }
        public string StatusName { get; set; } = null!;

    }

    public class ContractStatusEditDto : ContractStatusDto { }
}
