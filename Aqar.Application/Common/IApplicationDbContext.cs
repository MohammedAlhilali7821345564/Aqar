using Aqar.Domain.Common;
using Aqar.Domain.Contracts;
using Aqar.Domain.Expenses;
using Aqar.Domain.Identity;
using Aqar.Domain.Lookups;
using Aqar.Domain.RealEstate;
using Aqar.Domain.Utilities;
using Aqar.Domain.Vouchers;
using Microsoft.EntityFrameworkCore;

namespace Aqar.Application.Common
{
    public interface IApplicationDbContext
    {

        //Common
        DbSet<Attachment> Attachments { get; }
        DbSet<AuditLog> AuditLogs { get; }
        DbSet<Currency> Currencies { get; }
        DbSet<Setting> Settings { get; }

        //  Contracts
        DbSet<Contract> Contracts { get; }
        DbSet<ContractCharge> ContractCharges { get; }

        //  Expenses
       DbSet<PropertyExpense> PropertyExpenses { get; }
       DbSet<PropertyExpenseAllocation> PropertyExpenseAllocations { get; }
        // Identity
       DbSet<Role> Roles { get; }
        DbSet<Supplier> Suppliers { get; }
        DbSet<Tenant> Tenants { get; }
        DbSet<User> Users { get; }

        //  Lookups
        DbSet<AllocationMethod> AllocationMethods { get; }
        DbSet<ChargeType> ChargeTypes { get; }
        DbSet<ContractStatus> ContractStatuses { get; }
        DbSet<ExpenseType> ExpenseTypes { get; }
        DbSet<PaymentMethod> PaymentMethods { get; }
        DbSet<PaymentTimingType> PaymentTimingTypes { get; }
        DbSet<UnitType> UnitTypes { get; }
        DbSet<VoucherStatus> VoucherStatuses { get; }
        DbSet<VoucherType> VoucherTypes { get; }


        // RealEstate
        DbSet<Floor> Floors { get; }
        DbSet<Owner> Owners { get; }
        DbSet<Property> Properties { get; }
        DbSet<PropertyOwner> PropertyOwners { get; }
        DbSet<Unit> Units { get; }

        //  Utilities
        DbSet<ElectricityMainMeter> ElectricityMainMeters { get; }
        DbSet<ElectricityMainMeterReading> ElectricityMainMeterReadings { get; }
        DbSet<ElectricityUnitMeter> ElectricityUnitMeters { get; }
        DbSet<ElectricityUnitReading> ElectricityUnitReadings { get; }
        DbSet<UtilityRate> UtilityRates { get; }
        DbSet<WaterMeter> WaterMeters { get; }
        DbSet<WaterPurchase> WaterPurchases { get; }
        DbSet<WaterUnitReading> WaterUnitReadings { get; }

        //  Vouchers
        DbSet<Voucher> Vouchers { get; }
        DbSet<VoucherAllocation> VoucherAllocations { get; }

        // End Entity DBContext

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}