namespace Aqar.Domain.Contracts;

// ذمّة مالية مستحقة على عقد — تاريخ استحقاق + مبلغ + قابلة للإلغاء. تُستخدم لتسوية السندات عليها.
public partial class ContractCharge
{
    public long ChargeId { get; set; }

    public int ContractId { get; set; }

    public byte ChargeTypeId { get; set; }

    public DateOnly? PeriodMonth { get; set; }

    public DateOnly DueDate { get; set; }

    public string? Description { get; set; }

    public decimal Amount { get; set; }

    public bool IsCancelled { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public virtual ChargeType ChargeType { get; set; } = null!;

    public virtual Contract Contract { get; set; } = null!;

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<ElectricityUnitReading> ElectricityUnitReadings { get; set; } = new List<ElectricityUnitReading>();

    public virtual ICollection<PropertyExpenseAllocation> PropertyExpenseAllocations { get; set; } = new List<PropertyExpenseAllocation>();

    public virtual ICollection<VoucherAllocation> VoucherAllocations { get; set; } = new List<VoucherAllocation>();

    public virtual ICollection<WaterUnitReading> WaterUnitReadings { get; set; } = new List<WaterUnitReading>();
}
