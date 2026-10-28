
/*
using Aqar.Application.Common;
using Aqar.Domain.Account;
using Aqar.Domain.Core;
using Aqar.Domain.Lookups;
using Aqar.Domain.RealEstate;
using Aqar.Domain.Core;
using Aqar.Domain.Utilities;
using Aqar.Infrastructure.EntityConfigrtion.Account;
using Aqar.Infrastructure.EntityConfigrtion.Core;
using Aqar.Infrastructure.EntityConfigrtion.Lookups;
using Aqar.Infrastructure.EntityConfigrtion.RealEstate;
using Aqar.Infrastructure.EntityConfigrtion.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public partial class PropertyMgmtDbContext : DbContext
{
    public PropertyMgmtDbContext()
    {
    }

    public PropertyMgmtDbContext(DbContextOptions<PropertyMgmtDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AllocationMethod> AllocationMethods { get; set; }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<ChargeType> ChargeTypes { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<ContractCharge> ContractCharges { get; set; }

    public virtual DbSet<ContractStatus> ContractStatuses { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<ElectricityMainMeter> ElectricityMainMeters { get; set; }

    public virtual DbSet<ElectricityMainMeterReading> ElectricityMainMeterReadings { get; set; }

    public virtual DbSet<ElectricityUnitMeter> ElectricityUnitMeters { get; set; }

    public virtual DbSet<ElectricityUnitReading> ElectricityUnitReadings { get; set; }

    public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }

    public virtual DbSet<Floor> Floors { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<PaymentTimingType> PaymentTimingTypes { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<PropertyExpense> PropertyExpenses { get; set; }

    public virtual DbSet<PropertyExpenseAllocation> PropertyExpenseAllocations { get; set; }

    public virtual DbSet<PropertyOwner> PropertyOwners { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<UnitType> UnitTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UtilityRate> UtilityRates { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    public virtual DbSet<VoucherAllocation> VoucherAllocations { get; set; }

    public virtual DbSet<VoucherStatus> VoucherStatuses { get; set; }

    public virtual DbSet<VoucherType> VoucherTypes { get; set; }

    public virtual DbSet<WaterMeter> WaterMeters { get; set; }

    public virtual DbSet<WaterPurchase> WaterPurchases { get; set; }

    public virtual DbSet<WaterUnitReading> WaterUnitReadings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=PropertyMgmtDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AllocationMethod>(entity =>
        {
            entity.HasKey(e => e.MethodId);

            entity.HasIndex(e => e.MethodName, "UQ_AllocationMethods_name").IsUnique();

            entity.Property(e => e.MethodId).HasColumnName("method_id");
            entity.Property(e => e.MethodName)
                .HasMaxLength(50)
                .HasColumnName("method_name");
        });

        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasIndex(e => new { e.EntityType, e.EntityId }, "IX_Attachments_entity");

            entity.Property(e => e.AttachmentId)
                .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Seq_Attachments])")
                .HasColumnName("attachment_id");
            entity.Property(e => e.ContentType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("content_type");
            entity.Property(e => e.EntityId).HasColumnName("entity_id");
            entity.Property(e => e.EntityType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("entity_type");
            entity.Property(e => e.FileName)
                .HasMaxLength(200)
                .HasColumnName("file_name");
            entity.Property(e => e.FilePath)
                .HasMaxLength(500)
                .HasColumnName("file_path");
            entity.Property(e => e.FileSize).HasColumnName("file_size");
            entity.Property(e => e.UploadedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("uploaded_at");
            entity.Property(e => e.UploadedBy).HasColumnName("uploaded_by");

            entity.HasOne(d => d.UploadedByNavigation).WithMany(p => p.Attachments)
                .HasForeignKey(d => d.UploadedBy)
                .HasConstraintName("FK_Attach_Users");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.AuditId);

            entity.HasIndex(e => e.CreatedAt, "IX_AuditLogs_created").IsDescending();

            entity.HasIndex(e => new { e.EntityType, e.EntityId }, "IX_AuditLogs_entity");

            entity.Property(e => e.AuditId)
                .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Seq_AuditLogs])")
                .HasColumnName("audit_id");
            entity.Property(e => e.Action)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("action");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.EntityId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("entity_id");
            entity.Property(e => e.EntityType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("entity_type");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("ip_address");
            entity.Property(e => e.NewValues).HasColumnName("new_values");
            entity.Property(e => e.OldValues).HasColumnName("old_values");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Audit_Users");
        });

        modelBuilder.Entity<ChargeType>(entity =>
        {
            entity.HasIndex(e => e.ChargeTypeName, "UQ_ChargeTypes_name").IsUnique();

            entity.Property(e => e.ChargeTypeId).HasColumnName("charge_type_id");
            entity.Property(e => e.ChargeTypeName)
                .HasMaxLength(50)
                .HasColumnName("charge_type_name");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasIndex(e => new { e.StatusId, e.EndDate }, "IX_Contracts_status");

            entity.HasIndex(e => e.StatusId, "IX_Contracts_status_id");

            entity.HasIndex(e => e.TenantId, "IX_Contracts_tenant");

            entity.HasIndex(e => e.UnitId, "IX_Contracts_unit");

            entity.HasIndex(e => e.ContractNumber, "UQ_Contracts_number").IsUnique();

            entity.Property(e => e.ContractId)
                .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Seq_Contracts])")
                .HasColumnName("contract_id");
            entity.Property(e => e.AdvanceAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("advance_amount");
            entity.Property(e => e.AdvanceMonths).HasColumnName("advance_months");
            entity.Property(e => e.AdvanceMonthsConsumed).HasColumnName("advance_months_consumed");
            entity.Property(e => e.ContractNumber)
                .HasMaxLength(50)
                .HasColumnName("contract_number");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DepositAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("deposit_amount");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.MonthlyRent)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("monthly_rent");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .HasColumnName("notes");
            entity.Property(e => e.PaymentFrequencyMonths)
                .HasDefaultValue((byte)1)
                .HasColumnName("payment_frequency_months");
            entity.Property(e => e.PaymentTimingId).HasColumnName("payment_timing_id");
            entity.Property(e => e.RentStartDate).HasColumnName("rent_start_date");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TenantId).HasColumnName("tenant_id");
            entity.Property(e => e.TerminatedDate).HasColumnName("terminated_date");
            entity.Property(e => e.TerminationReason)
                .HasMaxLength(300)
                .HasColumnName("termination_reason");
            entity.Property(e => e.UnitId).HasColumnName("unit_id");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ContractCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Contracts_CreatedBy");

            entity.HasOne(d => d.PaymentTiming).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.PaymentTimingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contracts_Timing");

            entity.HasOne(d => d.Status).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contracts_Status");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contracts_Tenants");

            entity.HasOne(d => d.Unit).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contracts_Units");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ContractUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_Contracts_UpdatedBy");
        });

        modelBuilder.Entity<ContractCharge>(entity =>
        {
            entity.HasKey(e => e.ChargeId);

            entity.HasIndex(e => new { e.ContractId, e.DueDate }, "IX_Charges_contract_due");

            entity.HasIndex(e => e.DueDate, "IX_Charges_open_due").HasFilter("([is_cancelled]=(0))");

            entity.HasIndex(e => e.ChargeTypeId, "IX_Charges_type_id");

            entity.HasIndex(e => new { e.ContractId, e.ChargeTypeId, e.PeriodMonth }, "UQ_Charges_open")
                .IsUnique()
                .HasFilter("([period_month] IS NOT NULL AND [is_cancelled]=(0))");

            entity.Property(e => e.ChargeId)
                .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Seq_Charges])")
                .HasColumnName("charge_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.ChargeTypeId).HasColumnName("charge_type_id");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasColumnName("description");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.IsCancelled).HasColumnName("is_cancelled");
            entity.Property(e => e.PeriodMonth).HasColumnName("period_month");

            entity.HasOne(d => d.ChargeType).WithMany(p => p.ContractCharges)
                .HasForeignKey(d => d.ChargeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Charges_Types");

            entity.HasOne(d => d.Contract).WithMany(p => p.ContractCharges)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Charges_Contracts");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ContractCharges)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Charges_CreatedBy");
        });

        modelBuilder.Entity<ContractStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId);

            entity.HasIndex(e => e.StatusName, "UQ_ContractStatuses_name").IsUnique();

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasIndex(e => e.IsoCode, "UQ_Currencies_iso").IsUnique();

            entity.Property(e => e.CurrencyId)
                .ValueGeneratedNever()
                .HasColumnName("currency_id");
            entity.Property(e => e.CurrencyName)
                .HasMaxLength(50)
                .HasColumnName("currency_name");
            entity.Property(e => e.Decimals)
                .HasDefaultValue((byte)2)
                .HasColumnName("decimals");
            entity.Property(e => e.IsoCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("iso_code");
            entity.Property(e => e.Symbol)
                .HasMaxLength(10)
                .HasColumnName("symbol");
        });

        modelBuilder.Entity<ElectricityMainMeter>(entity =>
        {
            entity.HasKey(e => e.MainMeterId).HasName("PK_ElecMain");

            entity.HasIndex(e => e.PropertyId, "UX_ElecMain_one_active")
                .IsUnique()
                .HasFilter("([is_active]=(1))");

            entity.Property(e => e.MainMeterId).HasColumnName("main_meter_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.InstallDate).HasColumnName("install_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.MeterNumber)
                .HasMaxLength(50)
                .HasColumnName("meter_number");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");

            entity.HasOne(d => d.Property).WithOne(p => p.ElectricityMainMeter)
                .HasForeignKey<ElectricityMainMeter>(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElecMain_Properties");
        });

        modelBuilder.Entity<ElectricityMainMeterReading>(entity =>
        {
            entity.HasKey(e => e.MainReadingId).HasName("PK_ElecMainRead");

            entity.HasIndex(e => new { e.MainMeterId, e.PeriodMonth }, "UQ_ElecMainRead").IsUnique();

            entity.Property(e => e.MainReadingId).HasColumnName("main_reading_id");
            entity.Property(e => e.BillAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("bill_amount");
            entity.Property(e => e.Consumption)
                .HasComputedColumnSql("([current_reading]-[previous_reading])", true)
                .HasColumnType("decimal(19, 3)")
                .HasColumnName("consumption");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CurrentReading)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("current_reading");
            entity.Property(e => e.IsOpening).HasColumnName("is_opening");
            entity.Property(e => e.MainMeterId).HasColumnName("main_meter_id");
            entity.Property(e => e.Notes)
                .HasMaxLength(300)
                .HasColumnName("notes");
            entity.Property(e => e.PeriodMonth).HasColumnName("period_month");
            entity.Property(e => e.PreviousReading)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("previous_reading");
            entity.Property(e => e.ReadingDate).HasColumnName("reading_date");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ElectricityMainMeterReadings)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_ElecMainRead_CreatedBy");

            entity.HasOne(d => d.MainMeter).WithMany(p => p.ElectricityMainMeterReadings)
                .HasForeignKey(d => d.MainMeterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElecMainRead_Meter");
        });

        modelBuilder.Entity<ElectricityUnitMeter>(entity =>
        {
            entity.HasKey(e => e.UnitMeterId).HasName("PK_ElecUnit");

            entity.HasIndex(e => e.UnitId, "UX_ElecUnit_one_active")
                .IsUnique()
                .HasFilter("([is_active]=(1))");

            entity.Property(e => e.UnitMeterId).HasColumnName("unit_meter_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.MeterNumber)
                .HasMaxLength(50)
                .HasColumnName("meter_number");
            entity.Property(e => e.UnitId).HasColumnName("unit_id");

            entity.HasOne(d => d.Unit).WithOne(p => p.ElectricityUnitMeter)
                .HasForeignKey<ElectricityUnitMeter>(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElecUnit_Units");
        });

        modelBuilder.Entity<ElectricityUnitReading>(entity =>
        {
            entity.HasKey(e => e.ReadingId).HasName("PK_ElecUnitRead");

            entity.HasIndex(e => e.PeriodMonth, "IX_ElecUnitRead_period");

            entity.HasIndex(e => new { e.UnitMeterId, e.PeriodMonth }, "UQ_ElecUnitRead").IsUnique();

            entity.Property(e => e.ReadingId).HasColumnName("reading_id");
            entity.Property(e => e.Amount)
                .HasComputedColumnSql("(CONVERT([decimal](18,2),round(([current_reading]-[previous_reading])*isnull([price_per_unit],(0)),(2))))", true)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.ChargeId).HasColumnName("charge_id");
            entity.Property(e => e.Consumption)
                .HasComputedColumnSql("([current_reading]-[previous_reading])", true)
                .HasColumnType("decimal(19, 3)")
                .HasColumnName("consumption");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CurrentReading)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("current_reading");
            entity.Property(e => e.IsOpening).HasColumnName("is_opening");
            entity.Property(e => e.IsOwnerBorne).HasColumnName("is_owner_borne");
            entity.Property(e => e.Notes)
                .HasMaxLength(300)
                .HasColumnName("notes");
            entity.Property(e => e.PeriodMonth).HasColumnName("period_month");
            entity.Property(e => e.PreviousReading)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("previous_reading");
            entity.Property(e => e.PricePerUnit)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("price_per_unit");
            entity.Property(e => e.ReadingDate).HasColumnName("reading_date");
            entity.Property(e => e.UnitMeterId).HasColumnName("unit_meter_id");

            entity.HasOne(d => d.Charge).WithMany(p => p.ElectricityUnitReadings)
                .HasForeignKey(d => d.ChargeId)
                .HasConstraintName("FK_ElecUnitRead_Charges");

            entity.HasOne(d => d.Contract).WithMany(p => p.ElectricityUnitReadings)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK_ElecUnitRead_Contracts");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ElectricityUnitReadings)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_ElecUnitRead_CreatedBy");

            entity.HasOne(d => d.UnitMeter).WithMany(p => p.ElectricityUnitReadings)
                .HasForeignKey(d => d.UnitMeterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElecUnitRead_Meter");
        });

        modelBuilder.Entity<ExpenseType>(entity =>
        {
            entity.HasIndex(e => e.ExpenseTypeName, "UQ_ExpenseTypes_name").IsUnique();

            entity.Property(e => e.ExpenseTypeId).HasColumnName("expense_type_id");
            entity.Property(e => e.DefaultAllocationMethodId).HasColumnName("default_allocation_method_id");
            entity.Property(e => e.ExpenseTypeName)
                .HasMaxLength(100)
                .HasColumnName("expense_type_name");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");

            entity.HasOne(d => d.DefaultAllocationMethod).WithMany(p => p.ExpenseTypes)
                .HasForeignKey(d => d.DefaultAllocationMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExpenseTypes_Method");
        });

        modelBuilder.Entity<Floor>(entity =>
        {
            entity.HasIndex(e => new { e.PropertyId, e.FloorId }, "UQ_Floors_property_floorid").IsUnique();

            entity.HasIndex(e => new { e.PropertyId, e.FloorNumber }, "UQ_Floors_property_number").IsUnique();

            entity.Property(e => e.FloorId).HasColumnName("floor_id");
            entity.Property(e => e.FloorName)
                .HasMaxLength(50)
                .HasColumnName("floor_name");
            entity.Property(e => e.FloorNumber).HasColumnName("floor_number");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");

            entity.HasOne(d => d.Property).WithMany(p => p.Floors)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Floors_Properties");
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasIndex(e => e.OwnerId, "IX_Owners_active").HasFilter("([deleted_at] IS NULL AND [is_active]=(1))");

            entity.HasIndex(e => e.OwnerName, "IX_Owners_name");

            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.Address)
                .HasMaxLength(300)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.NationalId)
                .HasMaxLength(20)
                .HasColumnName("national_id");
            entity.Property(e => e.OwnerName)
                .HasMaxLength(150)
                .HasColumnName("owner_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.Owners)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK_Owners_DeletedBy");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasIndex(e => e.PaymentMethodName, "UQ_PaymentMethods_name").IsUnique();

            entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
            entity.Property(e => e.PaymentMethodName)
                .HasMaxLength(50)
                .HasColumnName("payment_method_name");
        });

        modelBuilder.Entity<PaymentTimingType>(entity =>
        {
            entity.HasKey(e => e.TimingId);

            entity.HasIndex(e => e.TimingName, "UQ_PaymentTimingTypes_name").IsUnique();

            entity.Property(e => e.TimingId).HasColumnName("timing_id");
            entity.Property(e => e.TimingName)
                .HasMaxLength(50)
                .HasColumnName("timing_name");
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasIndex(e => e.PropertyName, "IX_Properties_name");

            entity.HasIndex(e => e.PropertyCode, "UQ_Properties_code").IsUnique();

            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.Address)
                .HasMaxLength(300)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.PropertyCode)
                .HasMaxLength(50)
                .HasColumnName("property_code");
            entity.Property(e => e.PropertyName)
                .HasMaxLength(150)
                .HasColumnName("property_name");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PropertyCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Properties_CreatedBy");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.PropertyDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK_Properties_DeletedBy");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.PropertyUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_Properties_UpdatedBy");
        });

        modelBuilder.Entity<PropertyExpense>(entity =>
        {
            entity.HasKey(e => e.ExpenseId);

            entity.HasIndex(e => new { e.PropertyId, e.PeriodMonth }, "IX_PE_property_month");

            entity.HasIndex(e => e.SupplierId, "IX_PE_supplier_id");

            entity.HasIndex(e => e.ExpenseTypeId, "IX_PE_type_id");

            entity.HasIndex(e => new { e.ExpenseTypeId, e.PeriodMonth }, "IX_PE_type_month");

            entity.Property(e => e.ExpenseId).HasColumnName("expense_id");
            entity.Property(e => e.AllocationMethodId).HasColumnName("allocation_method_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasColumnName("description");
            entity.Property(e => e.ExpenseDate).HasColumnName("expense_date");
            entity.Property(e => e.ExpenseTypeId).HasColumnName("expense_type_id");
            entity.Property(e => e.IsCancelled).HasColumnName("is_cancelled");
            entity.Property(e => e.OwnerAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("owner_amount");
            entity.Property(e => e.PeriodMonth).HasColumnName("period_month");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.VoucherId).HasColumnName("voucher_id");

            entity.HasOne(d => d.AllocationMethod).WithMany(p => p.PropertyExpenses)
                .HasForeignKey(d => d.AllocationMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PE_Method");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PropertyExpenseCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_PE_CreatedBy");

            entity.HasOne(d => d.ExpenseType).WithMany(p => p.PropertyExpenses)
                .HasForeignKey(d => d.ExpenseTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PE_Types");

            entity.HasOne(d => d.Property).WithMany(p => p.PropertyExpenses)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PE_Properties");

            entity.HasOne(d => d.Supplier).WithMany(p => p.PropertyExpenses)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_PE_Suppliers");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.PropertyExpenseUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_PE_UpdatedBy");

            entity.HasOne(d => d.Voucher).WithMany(p => p.PropertyExpenses)
                .HasForeignKey(d => d.VoucherId)
                .HasConstraintName("FK_PE_Vouchers");
        });

        modelBuilder.Entity<PropertyExpenseAllocation>(entity =>
        {
            entity.HasKey(e => e.AllocationId).HasName("PK_PEA");

            entity.HasIndex(e => new { e.ExpenseId, e.ContractId }, "UQ_PEA_expense_contract").IsUnique();

            entity.Property(e => e.AllocationId).HasColumnName("allocation_id");
            entity.Property(e => e.AllocatedAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("allocated_amount");
            entity.Property(e => e.ChargeId).HasColumnName("charge_id");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.ExpenseId).HasColumnName("expense_id");

            entity.HasOne(d => d.Charge).WithMany(p => p.PropertyExpenseAllocations)
                .HasForeignKey(d => d.ChargeId)
                .HasConstraintName("FK_PEA_Charges");

            entity.HasOne(d => d.Contract).WithMany(p => p.PropertyExpenseAllocations)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PEA_Contracts");

            entity.HasOne(d => d.Expense).WithMany(p => p.PropertyExpenseAllocations)
                .HasForeignKey(d => d.ExpenseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PEA_Expenses");
        });

        modelBuilder.Entity<PropertyOwner>(entity =>
        {
            entity.HasKey(e => new { e.PropertyId, e.OwnerId });

            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.SharePercent)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("share_percent");

            entity.HasOne(d => d.Owner).WithMany(p => p.PropertyOwners)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PO_Owners");

            entity.HasOne(d => d.Property).WithMany(p => p.PropertyOwners)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PO_Properties");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasIndex(e => e.RoleName, "UQ_Roles_name").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.Property(e => e.SettingId).HasColumnName("setting_id");
            entity.Property(e => e.BaseCurrencyId).HasColumnName("base_currency_id");
            entity.Property(e => e.CompanyAddress)
                .HasMaxLength(300)
                .HasColumnName("company_address");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(150)
                .HasColumnName("company_name");
            entity.Property(e => e.CompanyPhone)
                .HasMaxLength(50)
                .HasColumnName("company_phone");
            entity.Property(e => e.ContractExpiryAlertDays)
                .HasDefaultValue((short)60)
                .HasColumnName("contract_expiry_alert_days");
            entity.Property(e => e.DefaultPropertyId).HasColumnName("default_property_id");
            entity.Property(e => e.LateGraceDays).HasColumnName("late_grace_days");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.BaseCurrency).WithMany(p => p.Settings)
                .HasForeignKey(d => d.BaseCurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Settings_Currency");

            entity.HasOne(d => d.DefaultProperty).WithMany(p => p.Settings)
                .HasForeignKey(d => d.DefaultPropertyId)
                .HasConstraintName("FK_Settings_Property");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.Settings)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_Settings_UpdatedBy");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasIndex(e => e.SupplierName, "IX_Suppliers_name");

            entity.HasIndex(e => e.SupplierCode, "UQ_Suppliers_code").IsUnique();

            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.Address)
                .HasMaxLength(300)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Mobile)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("mobile");
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.SupplierCategory)
                .HasMaxLength(50)
                .HasColumnName("supplier_category");
            entity.Property(e => e.SupplierCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("supplier_code");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(100)
                .HasColumnName("supplier_name");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK_Suppliers_DeletedBy");
        });

        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.HasIndex(e => e.TenantId, "IX_Tenants_active").HasFilter("([deleted_at] IS NULL AND [is_active]=(1))");

            entity.HasIndex(e => e.TenantName, "IX_Tenants_name");

            entity.HasIndex(e => e.NationalId, "IX_Tenants_national").HasFilter("([national_id] IS NOT NULL)");

            entity.HasIndex(e => e.TenantCode, "UQ_Tenants_code").IsUnique();

            entity.Property(e => e.TenantId).HasColumnName("tenant_id");
            entity.Property(e => e.Address)
                .HasMaxLength(300)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Mobile)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("mobile");
            entity.Property(e => e.NationalId)
                .HasMaxLength(20)
                .HasColumnName("national_id");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .HasColumnName("notes");
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.TenantCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tenant_code");
            entity.Property(e => e.TenantName)
                .HasMaxLength(100)
                .HasColumnName("tenant_name");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TenantCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Tenants_CreatedBy");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.TenantDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK_Tenants_DeletedBy");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TenantUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_Tenants_UpdatedBy");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasIndex(e => new { e.PropertyId, e.UnitId }, "IX_Units_active").HasFilter("([deleted_at] IS NULL AND [is_active]=(1))");

            entity.HasIndex(e => e.FloorId, "IX_Units_floor");

            entity.HasIndex(e => e.UnitTypeId, "IX_Units_unit_type_id");

            entity.HasIndex(e => new { e.PropertyId, e.UnitNumber }, "UQ_Units_property_number").IsUnique();

            entity.Property(e => e.UnitId).HasColumnName("unit_id");
            entity.Property(e => e.AreaSqm)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("area_sqm");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DefaultRentAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("default_rent_amount");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.FloorId).HasColumnName("floor_id");
            entity.Property(e => e.HasElectricity)
                .HasDefaultValue(true)
                .HasColumnName("has_electricity");
            entity.Property(e => e.HasWater)
                .HasDefaultValue(true)
                .HasColumnName("has_water");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.RoomsCount).HasColumnName("rooms_count");
            entity.Property(e => e.UnitNumber)
                .HasMaxLength(50)
                .HasColumnName("unit_number");
            entity.Property(e => e.UnitTypeId).HasColumnName("unit_type_id");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UnitCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Units_CreatedBy");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.UnitDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK_Units_DeletedBy");

            entity.HasOne(d => d.Property).WithMany(p => p.Units)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Units_Properties");

            entity.HasOne(d => d.UnitType).WithMany(p => p.Units)
                .HasForeignKey(d => d.UnitTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Units_Types");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.UnitUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_Units_UpdatedBy");

            entity.HasOne(d => d.Floor).WithMany(p => p.Units)
                .HasPrincipalKey(p => new { p.PropertyId, p.FloorId })
                .HasForeignKey(d => new { d.PropertyId, d.FloorId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Units_Floor_Property");
        });

        modelBuilder.Entity<UnitType>(entity =>
        {
            entity.HasIndex(e => e.UnitTypeName, "UQ_UnitTypes_name").IsUnique();

            entity.Property(e => e.UnitTypeId).HasColumnName("unit_type_id");
            entity.Property(e => e.UnitTypeName)
                .HasMaxLength(50)
                .HasColumnName("unit_type_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_Users_role_id");

            entity.HasIndex(e => e.UserName, "UQ_Users_name").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LastLoginAt)
                .HasPrecision(0)
                .HasColumnName("last_login_at");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(512)
                .HasColumnName("password_hash");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("user_name");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        modelBuilder.Entity<UtilityRate>(entity =>
        {
            entity.HasKey(e => e.RateId);

            entity.HasIndex(e => new { e.PropertyId, e.UtilityType, e.EffectiveFrom }, "UQ_UR").IsUnique();

            entity.Property(e => e.RateId).HasColumnName("rate_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.EffectiveFrom).HasColumnName("effective_from");
            entity.Property(e => e.PricePerUnit)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("price_per_unit");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.UtilityType).HasColumnName("utility_type");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UtilityRates)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_UR_CreatedBy");

            entity.HasOne(d => d.Property).WithMany(p => p.UtilityRates)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UR_Properties");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasIndex(e => e.ContractId, "IX_Vouchers_contract");

            entity.HasIndex(e => new { e.VoucherDate, e.VoucherTypeId }, "IX_Vouchers_date");

            entity.HasIndex(e => e.PaymentMethodId, "IX_Vouchers_method_id");

            entity.HasIndex(e => new { e.PropertyId, e.VoucherDate }, "IX_Vouchers_property");

            entity.HasIndex(e => e.StatusId, "IX_Vouchers_status_id");

            entity.HasIndex(e => e.TenantId, "IX_Vouchers_tenant").HasFilter("([tenant_id] IS NOT NULL)");

            entity.HasIndex(e => e.VoucherTypeId, "IX_Vouchers_type_id");

            entity.HasIndex(e => e.VoucherNumber, "UQ_Vouchers_number").IsUnique();

            entity.Property(e => e.VoucherId)
                .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Seq_Vouchers])")
                .HasColumnName("voucher_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.BankName)
                .HasMaxLength(100)
                .HasColumnName("bank_name");
            entity.Property(e => e.CancelReason)
                .HasMaxLength(300)
                .HasColumnName("cancel_reason");
            entity.Property(e => e.CancelledAt)
                .HasPrecision(0)
                .HasColumnName("cancelled_at");
            entity.Property(e => e.CancelledBy).HasColumnName("cancelled_by");
            entity.Property(e => e.ChequeDate).HasColumnName("cheque_date");
            entity.Property(e => e.ChequeNumber)
                .HasMaxLength(50)
                .HasColumnName("cheque_number");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(50)
                .HasColumnName("reference_number");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.TenantId).HasColumnName("tenant_id");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.VoucherDate).HasColumnName("voucher_date");
            entity.Property(e => e.VoucherNumber)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("voucher_number");
            entity.Property(e => e.VoucherTypeId).HasColumnName("voucher_type_id");

            entity.HasOne(d => d.CancelledByNavigation).WithMany(p => p.VoucherCancelledByNavigations)
                .HasForeignKey(d => d.CancelledBy)
                .HasConstraintName("FK_Vouchers_CancelledBy");

            entity.HasOne(d => d.Contract).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK_Vouchers_Contracts");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.VoucherCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Vouchers_CreatedBy");

            entity.HasOne(d => d.Owner).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK_Vouchers_Owners");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vouchers_Method");

            entity.HasOne(d => d.Property).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.PropertyId)
                .HasConstraintName("FK_Vouchers_Properties");

            entity.HasOne(d => d.Status).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vouchers_Status");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Vouchers_Suppliers");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.TenantId)
                .HasConstraintName("FK_Vouchers_Tenants");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.VoucherUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_Vouchers_UpdatedBy");

            entity.HasOne(d => d.VoucherType).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.VoucherTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vouchers_Types");
        });

        modelBuilder.Entity<VoucherAllocation>(entity =>
        {
            entity.HasKey(e => e.AllocationId);

            entity.HasIndex(e => e.ChargeId, "IX_VA_charge");

            entity.HasIndex(e => new { e.VoucherId, e.ChargeId }, "UQ_VA_voucher_charge").IsUnique();

            entity.Property(e => e.AllocationId).HasColumnName("allocation_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.ChargeId).HasColumnName("charge_id");
            entity.Property(e => e.VoucherId).HasColumnName("voucher_id");

            entity.HasOne(d => d.Charge).WithMany(p => p.VoucherAllocations)
                .HasForeignKey(d => d.ChargeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VA_Charges");

            entity.HasOne(d => d.Voucher).WithMany(p => p.VoucherAllocations)
                .HasForeignKey(d => d.VoucherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VA_Vouchers");
        });

        modelBuilder.Entity<VoucherStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId);

            entity.HasIndex(e => e.StatusName, "UQ_VoucherStatuses_name").IsUnique();

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<VoucherType>(entity =>
        {
            entity.HasIndex(e => e.VoucherTypeCode, "UQ_VoucherTypes_code").IsUnique();

            entity.Property(e => e.VoucherTypeId).HasColumnName("voucher_type_id");
            entity.Property(e => e.NumberPrefix)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("number_prefix");
            entity.Property(e => e.VoucherTypeCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("voucher_type_code");
            entity.Property(e => e.VoucherTypeName)
                .HasMaxLength(50)
                .HasColumnName("voucher_type_name");
        });

        modelBuilder.Entity<WaterMeter>(entity =>
        {
            entity.HasIndex(e => e.UnitId, "UX_WaterMeters_one_active")
                .IsUnique()
                .HasFilter("([is_active]=(1))");

            entity.Property(e => e.WaterMeterId).HasColumnName("water_meter_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.MeterNumber)
                .HasMaxLength(50)
                .HasColumnName("meter_number");
            entity.Property(e => e.UnitId).HasColumnName("unit_id");

            entity.HasOne(d => d.Unit).WithOne(p => p.WaterMeter)
                .HasForeignKey<WaterMeter>(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WaterMeters_Units");
        });

        modelBuilder.Entity<WaterPurchase>(entity =>
        {
            entity.HasKey(e => e.PurchaseId);

            entity.HasIndex(e => new { e.PropertyId, e.PeriodMonth }, "IX_WP_property_month");

            entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasColumnName("description");
            entity.Property(e => e.PeriodMonth).HasColumnName("period_month");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_date");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("quantity");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.VoucherId).HasColumnName("voucher_id");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WaterPurchases)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_WP_CreatedBy");

            entity.HasOne(d => d.Property).WithMany(p => p.WaterPurchases)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WP_Properties");

            entity.HasOne(d => d.Supplier).WithMany(p => p.WaterPurchases)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_WP_Suppliers");

            entity.HasOne(d => d.Voucher).WithMany(p => p.WaterPurchases)
                .HasForeignKey(d => d.VoucherId)
                .HasConstraintName("FK_WP_Vouchers");
        });

        modelBuilder.Entity<WaterUnitReading>(entity =>
        {
            entity.HasKey(e => e.ReadingId).HasName("PK_WaterUnitRead");

            entity.HasIndex(e => e.PeriodMonth, "IX_WaterUnitRead_period");

            entity.HasIndex(e => new { e.WaterMeterId, e.PeriodMonth }, "UQ_WaterUnitRead").IsUnique();

            entity.Property(e => e.ReadingId).HasColumnName("reading_id");
            entity.Property(e => e.Amount)
                .HasComputedColumnSql("(CONVERT([decimal](18,2),round(([current_reading]-[previous_reading])*isnull([price_per_unit],(0)),(2))))", true)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.ChargeId).HasColumnName("charge_id");
            entity.Property(e => e.Consumption)
                .HasComputedColumnSql("([current_reading]-[previous_reading])", true)
                .HasColumnType("decimal(19, 3)")
                .HasColumnName("consumption");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CurrentReading)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("current_reading");
            entity.Property(e => e.IsOpening).HasColumnName("is_opening");
            entity.Property(e => e.IsOwnerBorne).HasColumnName("is_owner_borne");
            entity.Property(e => e.Notes)
                .HasMaxLength(300)
                .HasColumnName("notes");
            entity.Property(e => e.PeriodMonth).HasColumnName("period_month");
            entity.Property(e => e.PreviousReading)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("previous_reading");
            entity.Property(e => e.PricePerUnit)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("price_per_unit");
            entity.Property(e => e.ReadingDate).HasColumnName("reading_date");
            entity.Property(e => e.WaterMeterId).HasColumnName("water_meter_id");

            entity.HasOne(d => d.Charge).WithMany(p => p.WaterUnitReadings)
                .HasForeignKey(d => d.ChargeId)
                .HasConstraintName("FK_WaterUnitRead_Charges");

            entity.HasOne(d => d.Contract).WithMany(p => p.WaterUnitReadings)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK_WaterUnitRead_Contracts");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WaterUnitReadings)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_WaterUnitRead_CreatedBy");

            entity.HasOne(d => d.WaterMeter).WithMany(p => p.WaterUnitReadings)
                .HasForeignKey(d => d.WaterMeterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WaterUnitRead_Meter");
        });
        modelBuilder.HasSequence("Seq_Attachments");
        modelBuilder.HasSequence("Seq_AuditLogs");
        modelBuilder.HasSequence("Seq_Charges");
        modelBuilder.HasSequence<int>("Seq_Contracts");
        modelBuilder.HasSequence<int>("Seq_Suppliers");
        modelBuilder.HasSequence<int>("Seq_Tenants");
        modelBuilder.HasSequence<int>("Seq_Vouchers");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
*/