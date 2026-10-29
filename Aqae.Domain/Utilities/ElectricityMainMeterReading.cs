
namespace Aqar.Domain.Utilities
{
public partial class ElectricityMainMeterReading
    {//قراءة   للعداد الرئيسي — تحسب الاستهلاك والفاتورة.
    public int MainReadingId { get; set; }

    public int MainMeterId { get; set; }

    public DateOnly PeriodMonth { get; set; }

    public DateOnly ReadingDate { get; set; }

    public decimal PreviousReading { get; set; }

    public decimal CurrentReading { get; set; }

    public decimal? Consumption { get; set; }

    public decimal? BillAmount { get; set; }

    public bool IsOpening { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ElectricityMainMeter MainMeter { get; set; } = null!;
}
}