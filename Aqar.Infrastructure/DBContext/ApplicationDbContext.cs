using Aqar.Application.Common;
using Aqar.Domain.Base;
using Aqar.Domain.Common;
using Aqar.Domain.Contracts;
using Aqar.Domain.Expenses;
using Aqar.Domain.Identity;
using Aqar.Domain.Lookups;
using Aqar.Domain.RealEstate;
using Aqar.Domain.Utilities;
using Aqar.Domain.Vouchers;
using Aqar.Infrastructure.EntityConfigrtion.Common;
using Aqar.Infrastructure.EntityConfigrtion.Contracts;
using Aqar.Infrastructure.EntityConfigrtion.Expenses;
using Aqar.Infrastructure.EntityConfigrtion.Identity;
using Aqar.Infrastructure.EntityConfigrtion.Lookups;
using Aqar.Infrastructure.EntityConfigrtion.RealEstate;
using Aqar.Infrastructure.EntityConfigrtion.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Aqar.Infrastructure.DBContext;

public partial class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    //Common
    public DbSet<Attachment> Attachments => Set<Attachment>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<Currency> Currencies => Set<Currency>();
    public DbSet<Setting> Settings => Set<Setting>();

    //  Contracts
    public DbSet<Contract> Contracts => Set<Contract>();
    public DbSet<ContractCharge> ContractCharges => Set<ContractCharge>();
    
    //  Expenses
    public DbSet<PropertyExpense> PropertyExpenses => Set<PropertyExpense>();
    public DbSet<PropertyExpenseAllocation> PropertyExpenseAllocations => Set<PropertyExpenseAllocation>();

    // Identity
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<User> Users => Set<User>();

    //  Lookups
    public DbSet<AllocationMethod> AllocationMethods => Set<AllocationMethod>();
    public DbSet<ChargeType> ChargeTypes => Set<ChargeType>();
    public DbSet<ContractStatus> ContractStatuses => Set<ContractStatus>();
    public DbSet<ExpenseType> ExpenseTypes => Set<ExpenseType>();
    public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();
    public DbSet<PaymentTimingType> PaymentTimingTypes => Set<PaymentTimingType>();
    public DbSet<UnitType> UnitTypes => Set<UnitType>();
    public DbSet<VoucherStatus> VoucherStatuses => Set<VoucherStatus>();
    public DbSet<VoucherType> VoucherTypes => Set<VoucherType>();


    // RealEstate
    public DbSet<Floor> Floors => Set<Floor>();
    public DbSet<Owner> Owners => Set<Owner>();
    public DbSet<Property> Properties => Set<Property>();
    public DbSet<PropertyOwner> PropertyOwners => Set<PropertyOwner>();
    public DbSet<Unit> Units => Set<Unit>();

    //  Utilities
    public DbSet<ElectricityMainMeter> ElectricityMainMeters => Set<ElectricityMainMeter>();
    public DbSet<ElectricityMainMeterReading> ElectricityMainMeterReadings => Set<ElectricityMainMeterReading>();
    public DbSet<ElectricityUnitMeter> ElectricityUnitMeters => Set<ElectricityUnitMeter>();
    public DbSet<ElectricityUnitReading> ElectricityUnitReadings => Set<ElectricityUnitReading>();
    public DbSet<UtilityRate> UtilityRates => Set<UtilityRate>();
    public DbSet<WaterMeter> WaterMeters => Set<WaterMeter>();
    public DbSet<WaterPurchase> WaterPurchases => Set<WaterPurchase>();
    public DbSet<WaterUnitReading> WaterUnitReadings => Set<WaterUnitReading>();

    //  Vouchers
    public DbSet<Voucher> Vouchers => Set<Voucher>();
    public DbSet<VoucherAllocation> VoucherAllocations => Set<VoucherAllocation>();

    // End Entity DBContext


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<TraceEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    break;

                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    break;

                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.Entity.DeletedAt = DateTime.UtcNow;
                    break;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasSequence("Seq_Attachments");
        modelBuilder.HasSequence("Seq_AuditLogs");
        modelBuilder.HasSequence("Seq_Charges");
        modelBuilder.HasSequence<int>("Seq_Contracts");
        modelBuilder.HasSequence<int>("Seq_Suppliers");
        modelBuilder.HasSequence<int>("Seq_Tenants");
        modelBuilder.HasSequence<int>("Seq_Vouchers");

        // Common
        modelBuilder.ApplyConfiguration(new AttachmentConfig());
        modelBuilder.ApplyConfiguration(new AuditLogConfig());
        modelBuilder.ApplyConfiguration(new CurrencyConfig());
        modelBuilder.ApplyConfiguration(new SettingConfig());

        // Contract
        modelBuilder.ApplyConfiguration(new ContractChargeConfig());
        modelBuilder.ApplyConfiguration(new ContractConfig());

        // Expenses
        modelBuilder.ApplyConfiguration(new PropertyExpenseAllocationConfig());
        modelBuilder.ApplyConfiguration(new PropertyExpenseConfig());

        //Identity
        modelBuilder.ApplyConfiguration(new RoleConfig());
        modelBuilder.ApplyConfiguration(new SupplierConfig());
        modelBuilder.ApplyConfiguration(new TenantConfig());
        modelBuilder.ApplyConfiguration(new UserConfig());

        // LooKups
        modelBuilder.ApplyConfiguration(new AllocationMethodConfig());
        modelBuilder.ApplyConfiguration(new ChargeTypeConfig());
        modelBuilder.ApplyConfiguration(new ContractStatusConfig());
        modelBuilder.ApplyConfiguration(new ExpenseTypeConfig());
        modelBuilder.ApplyConfiguration(new PaymentMethodConfig());
        modelBuilder.ApplyConfiguration(new PaymentTimingTypeConfig());
        modelBuilder.ApplyConfiguration(new UnitTypeConfig());
        modelBuilder.ApplyConfiguration(new VoucherStatusConfig());
        modelBuilder.ApplyConfiguration(new VoucherTypeConfig());

        //Realstate
        modelBuilder.ApplyConfiguration(new FloorConfig());
        modelBuilder.ApplyConfiguration(new OwnerConfig());
        modelBuilder.ApplyConfiguration(new PropertyConfig());
        modelBuilder.ApplyConfiguration(new PropertyOwnerConfig());
        modelBuilder.ApplyConfiguration(new UnitConfig());

        //Utilities
        modelBuilder.ApplyConfiguration(new ElectricityMainMeterConfig());
        modelBuilder.ApplyConfiguration(new ElectricityMainMeterReadingConfig());
        modelBuilder.ApplyConfiguration(new ElectricityUnitMeterConfig());
        modelBuilder.ApplyConfiguration(new ElectricityUnitReadingConfig());

        modelBuilder.ApplyConfiguration(new UtilityRateConfig());
        modelBuilder.ApplyConfiguration(new WaterMeterConfig());
        modelBuilder.ApplyConfiguration(new WaterPurchaseConfig());
        modelBuilder.ApplyConfiguration(new WaterUnitReadingConfig());
    }
}  