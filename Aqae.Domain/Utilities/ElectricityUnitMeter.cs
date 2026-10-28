namespace Aqar.Domain.Utilities
{
    public partial class ElectricityUnitMeter
    {//عداد كهرباء فرعي لكل وحدة — واحد نشط لكل وحدة.
        public int UnitMeterId { get; set; }

        public int UnitId { get; set; }

        public string? MeterNumber { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ICollection<ElectricityUnitReading> ElectricityUnitReadings { get; set; } = new List<ElectricityUnitReading>();

        public virtual Unit Unit { get; set; } = null!;
    }
}
