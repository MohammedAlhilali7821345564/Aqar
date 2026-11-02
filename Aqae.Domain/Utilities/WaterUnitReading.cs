namespace Aqar.Domain.Utilities;

public partial class WaterUnitReading
{//قراءة شهرية لعداد المياه — نفس منطق ElectricityUnitReading.
    public long ReadingId { get; set; }

    public int WaterMeterId { get; set; }

    public DateOnly PeriodMonth { get; set; }

    public DateOnly ReadingDate { get; set; }

    public decimal PreviousReading { get; set; }

    public decimal CurrentReading { get; set; }

    public decimal? Consumption { get; set; }

    public decimal? PricePerUnit { get; set; }

    public decimal? Amount { get; set; }

    public int? ContractId { get; set; }

    public bool IsOwnerBorne { get; set; }

    public long? ChargeId { get; set; }

    public bool IsOpening { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? CreatedBy { get; set; }
    //public virtual User? CreatedByNavigation { get; set; }

    public virtual ContractCharge? Charge { get; set; }
    public virtual Contract? Contract { get; set; }
    public virtual WaterMeter WaterMeter { get; set; } = null!;
}
