
namespace Aqar.Domain.Utilities
{
    public partial class WaterMeter
    {//عداد مياه فرعي لكل وحدة.
        public int WaterMeterId { get; set; }

        public int UnitId { get; set; }

        public string? MeterNumber { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual Unit Unit { get; set; } = null!;

        public virtual ICollection<WaterUnitReading> WaterUnitReadings { get; set; } = new List<WaterUnitReading>();
    }
}
