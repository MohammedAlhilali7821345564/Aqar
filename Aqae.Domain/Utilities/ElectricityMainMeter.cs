
namespace Aqar.Domain.Utilities;

public partial class ElectricityMainMeter
{//العداد الرئيسي للكهرباء للعقار كله — عداد واحد نشط لكل عقار.
    public int MainMeterId { get; set; }

    public int PropertyId { get; set; }

    public string? MeterNumber { get; set; }

    public DateOnly? InstallDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<ElectricityMainMeterReading> ElectricityMainMeterReadings { get; set; } = new List<ElectricityMainMeterReading>();

    public virtual Property Property { get; set; } = null!;
}
