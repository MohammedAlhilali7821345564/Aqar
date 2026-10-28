using Aqar.Domain.Common;
using Aqar.Domain.Contracts;
using Aqar.Domain.Expenses;
using Aqar.Domain.Identity;
using Aqar.Domain.Lookups;
using Aqar.Domain.RealEstate;
using Aqar.Domain.Utilities;
using Aqar.Domain.Vouchers;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace Aqar.Application.Common
{
    public interface IApplicationDbContext
    {
        DbSet<AllocationMethod> AllocationMethods { get; }

        DbSet<Attachment> Attachments { get; }

        DbSet<AuditLog> AuditLogs { get; }

        DbSet<ChargeType> ChargeTypes { get; }

       DbSet<Contract> Contracts { get; }

       DbSet<ContractCharge> ContractCharges { get; }

       DbSet<ContractStatus> ContractStatuses { get; }

       DbSet<Currency> Currencies { get; }

       DbSet<ElectricityMainMeter> ElectricityMainMeters { get; }

       DbSet<ElectricityMainMeterReading> ElectricityMainMeterReadings { get; }

       DbSet<ElectricityUnitMeter> ElectricityUnitMeters { get; }

       DbSet<ElectricityUnitReading> ElectricityUnitReadings { get; }

       DbSet<ExpenseType> ExpenseTypes { get; }

       DbSet<Floor> Floors { get; }

       DbSet<Owner> Owners { get;}

       DbSet<PaymentMethod> PaymentMethods { get; }

       DbSet<PaymentTimingType> PaymentTimingTypes { get; }

       DbSet<Property> Properties { get; }

       DbSet<PropertyExpense> PropertyExpenses { get; }

      DbSet<PropertyExpenseAllocation> PropertyExpenseAllocations { get; }

       DbSet<PropertyOwner> PropertyOwners { get; }

       DbSet<Role> Roles { get; }

      DbSet<Setting> Settings { get;}

      DbSet<Supplier> Suppliers { get; }

      DbSet<Tenant> Tenants { get; }

      DbSet<Unit> Units { get; }

      DbSet<UnitType> UnitTypes { get; }

      DbSet<User> Users { get; }

      DbSet<UtilityRate> UtilityRates { get; }

      DbSet<Voucher> Vouchers { get; }

      DbSet<VoucherAllocation> VoucherAllocations { get; }

      DbSet<VoucherStatus> VoucherStatuses { get; }

      DbSet<VoucherType> VoucherTypes { get; }

      DbSet<WaterMeter> WaterMeters { get; }

      DbSet<WaterPurchase> WaterPurchases { get; }

      DbSet<Domain.Utilities.WaterUnitReading> WaterUnitReadings { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}