
namespace Aqar.Domain.Lookups;

public partial class AllocationMethod
{//  ØÑŞ ÊæÒíÚ ÇáãÕÑæİ Úáì ÇáæÍÏÇÊ (íÊÍãáå ÇáãÇáß/ÈÇáÊÓÇæí/ÍÓÈ ÇáãÓÇÍÉ/ãÈÇÔÑ Úáì ÚŞÏ).
    public byte MethodId { get; set; }

    public string MethodName { get; set; } = null!;

    public virtual ICollection<ExpenseType> ExpenseTypes { get; set; } = new List<ExpenseType>();

    public virtual ICollection<PropertyExpense> PropertyExpenses { get; set; } = new List<PropertyExpense>();
}
