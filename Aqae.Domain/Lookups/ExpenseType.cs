
namespace Aqar.Domain.Lookups;

public partial class ExpenseType
{// √‰Ê«⁄ «·„’«—Ì› (’Ì«‰…/‰Ÿ«›…/Õ—«”…/ﬂÂ—»«¡ Œœ„« 
    public short ExpenseTypeId { get; set; }

    public string ExpenseTypeName { get; set; } = null!;

    public byte DefaultAllocationMethodId { get; set; }

    public bool IsActive { get; set; }

    public virtual AllocationMethod DefaultAllocationMethod { get; set; } = null!;

    public virtual ICollection<PropertyExpense> PropertyExpenses { get; set; } = new List<PropertyExpense>();
}
