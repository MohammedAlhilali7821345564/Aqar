
namespace Aqar.Application.DTOs.Lookups
{
    public class ExpenseTypeDto
    {
        public short ExpenseTypeId { get; set; }

        public string ExpenseTypeName { get; set; } = null!;
        public byte DefaultAllocationMethodId { get; set; }

    }
    public class ExpenseTypeEditDto : ExpenseTypeDto { }
}
