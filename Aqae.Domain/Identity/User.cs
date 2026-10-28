
using Aqar.Domain.Contracts;
using Attachment = Aqar.Domain.Common.Attachment;

namespace Aqar.Domain.Identity;
//«·„” Œœ„Ê‰ «·„”Ã·Ê‰ ›Ì «·‰Ÿ«„° ·ﬂ· „” Œœ„ œÊ— Êﬂ·„… „—Ê— „‘›¯—….

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public byte RoleId { get; set; }

    public string PasswordHash { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime? LastLoginAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();

    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    public virtual ICollection<ContractCharge> ContractCharges { get; set; } = new List<ContractCharge>();

    public virtual ICollection<Contract> ContractCreatedByNavigations { get; set; } = new List<Contract>();

    public virtual ICollection<Contract> ContractUpdatedByNavigations { get; set; } = new List<Contract>();

    public virtual ICollection<ElectricityMainMeterReading> ElectricityMainMeterReadings { get; set; } = new List<ElectricityMainMeterReading>();

    public virtual ICollection<ElectricityUnitReading> ElectricityUnitReadings { get; set; } = new List<ElectricityUnitReading>();

    public virtual ICollection<Owner> Owners { get; set; } = new List<Owner>();

    public virtual ICollection<Property> PropertyCreatedByNavigations { get; set; } = new List<Property>();

    public virtual ICollection<Property> PropertyDeletedByNavigations { get; set; } = new List<Property>();

    public virtual ICollection<PropertyExpense> PropertyExpenseCreatedByNavigations { get; set; } = new List<PropertyExpense>();

    public virtual ICollection<PropertyExpense> PropertyExpenseUpdatedByNavigations { get; set; } = new List<PropertyExpense>();

    public virtual ICollection<Property> PropertyUpdatedByNavigations { get; set; } = new List<Property>();

    public virtual ICollection<Setting> Settings { get; set; } = new List<Setting>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();

    public virtual ICollection<Tenant> TenantCreatedByNavigations { get; set; } = new List<Tenant>();

    public virtual ICollection<Tenant> TenantDeletedByNavigations { get; set; } = new List<Tenant>();

    public virtual ICollection<Tenant> TenantUpdatedByNavigations { get; set; } = new List<Tenant>();

    public virtual ICollection<Unit> UnitCreatedByNavigations { get; set; } = new List<Unit>();

    public virtual ICollection<Unit> UnitDeletedByNavigations { get; set; } = new List<Unit>();

    public virtual ICollection<Unit> UnitUpdatedByNavigations { get; set; } = new List<Unit>();

    public virtual ICollection<UtilityRate> UtilityRates { get; set; } = new List<UtilityRate>();

    public virtual ICollection<Voucher> VoucherCancelledByNavigations { get; set; } = new List<Voucher>();

    public virtual ICollection<Voucher> VoucherCreatedByNavigations { get; set; } = new List<Voucher>();

    public virtual ICollection<Voucher> VoucherUpdatedByNavigations { get; set; } = new List<Voucher>();

    public virtual ICollection<WaterPurchase> WaterPurchases { get; set; } = new List<WaterPurchase>();

    public virtual ICollection<WaterUnitReading> WaterUnitReadings { get; set; } = new List<WaterUnitReading>();
}