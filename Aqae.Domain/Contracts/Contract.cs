
namespace Aqar.Domain.Contracts;

// عقد إيجار بين وحدة ومستأجر 
public partial class Contract
{
    public int ContractId { get; set; }

    public string ContractNumber { get; set; } = null!;

    public int UnitId { get; set; }

    public int TenantId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public DateOnly? RentStartDate { get; set; }

    public decimal MonthlyRent { get; set; }

    public byte PaymentFrequencyMonths { get; set; }

    public byte PaymentTimingId { get; set; }

    public decimal DepositAmount { get; set; }

    public byte AdvanceMonths { get; set; }

    public decimal AdvanceAmount { get; set; }

    public byte AdvanceMonthsConsumed { get; set; }

    public byte StatusId { get; set; }

    public DateOnly? TerminatedDate { get; set; }

    public string? TerminationReason { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual ICollection<ContractCharge> ContractCharges { get; set; } = new List<ContractCharge>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<ElectricityUnitReading> ElectricityUnitReadings { get; set; } = new List<ElectricityUnitReading>();

    public virtual PaymentTimingType PaymentTiming { get; set; } = null!;

    public virtual ICollection<PropertyExpenseAllocation> PropertyExpenseAllocations { get; set; } = new List<PropertyExpenseAllocation>();

    public virtual ContractStatus Status { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }

    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();

    public virtual ICollection<WaterUnitReading> WaterUnitReadings { get; set; } = new List<WaterUnitReading>();
}
