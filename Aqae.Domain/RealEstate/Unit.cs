namespace Aqar.Domain.RealEstate;

// الوحدة السكنية/التجارية داخل الطابق — مرتبطة بطابق   .
public partial class Unit:TraceEntity
{
    public int UnitId { get; set; }

    public int PropertyId { get; set; }

    public int FloorId { get; set; }

    public string UnitNumber { get; set; } = null!;

    public byte UnitTypeId { get; set; }

    public decimal? AreaSqm { get; set; }

    public byte? RoomsCount { get; set; }

    public decimal? DefaultRentAmount { get; set; }

    public bool HasElectricity { get; set; }

    public bool HasWater { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    //public DateTime CreatedAt { get; set; }

    //public int? CreatedBy { get; set; }

    //public DateTime? UpdatedAt { get; set; }

    //public int? UpdatedBy { get; set; }

    //public DateTime? DeletedAt { get; set; }

    //public int? DeletedBy { get; set; }

    //public virtual User? CreatedByNavigation { get; set; }

    //public virtual User? DeletedByNavigation { get; set; }
    //public virtual User? UpdatedByNavigation { get; set; }


    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ElectricityUnitMeter? ElectricityUnitMeter { get; set; }

    public virtual Floor Floor { get; set; } = null!;

    public virtual Property Property { get; set; } = null!;

    public virtual UnitType UnitType { get; set; } = null!;

    public virtual WaterMeter? WaterMeter { get; set; }
}
