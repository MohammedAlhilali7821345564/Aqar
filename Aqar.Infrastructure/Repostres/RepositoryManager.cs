using Aqar.Application.Interfaces.IRepository;
using Aqar.Application.Interfaces.IRepository.Common;
using Aqar.Application.Interfaces.IRepository.Expenses;
using Aqar.Application.Interfaces.IRepository.Identity;
using Aqar.Application.Interfaces.IRepository.Lookups;
using Aqar.Application.Interfaces.IRepository.RealEstate;
using Aqar.Application.Interfaces.IRepository.Vouchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqar.Infrastructure.Repostres
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IAttachmentRepository attachmentRepository;
        private readonly IAuditLogRepository auditLogRepository;
        private readonly ICurrencyRepository currencyRepository;
        private readonly ISettingRepository settingRepository;
        private readonly IPropertyExpenseAllocationRepoistory propertyExpenseAllocationRepoistory;
        private readonly IPropertyExpenseRepoistory propertyExpenseRepoistory;
        private IRoleRopsitory roleRopsitory;
        private readonly ISupplierRopsitory supplierRopsitory;
        private readonly ITenantRopsitory tenantRopsitory;
        private readonly IUserRopsitory userRopsitory;
        private readonly IOwnerRepository ownerRepository;
        private readonly IFloorRepository floorRepository;
        private readonly IUnitRepository unitRepository;
        private readonly IUnitTypeRepository unitTypeRepository;
        private readonly IVoucherRepository voucherRepository;
        private readonly IVoucherAllocationRepository voucherAllocationRepository;
        private readonly IVoucherStatusRepository voucherStatusRepository;
        private readonly IVoucherTypeRepository voucherTypeRepository;
        private readonly IChargeTypeRepository chargeTypeRepository;
        private readonly IContractStatusRepository contractStatusRepository;
        private readonly IExpenseTypeRepository expenseTypeRepository;
        private readonly IPaymentMethodRepository paymentMethodRepository;
        private readonly IPaymentTimingTypeRepository paymentTimingTypeRepository;
        private readonly IUnitOfWork unitOfWork;

        public RepositoryManager (

            IAttachmentRepository attachmentRepository,
            IAuditLogRepository auditLogRepository,

            ICurrencyRepository currencyRepository,
            ISettingRepository settingRepository,

            IPropertyExpenseAllocationRepoistory propertyExpenseAllocationRepoistory,
            IPropertyExpenseRepoistory propertyExpenseRepoistory,

            IRoleRopsitory roleRopsitory,

            ISupplierRopsitory supplierRopsitory,

            ITenantRopsitory tenantRopsitory,

            IUserRopsitory userRopsitory,

            IOwnerRepository ownerRepository,
            IFloorRepository floorRepository,

            IUnitRepository unitRepository,
            IUnitTypeRepository unitTypeRepository,

            IVoucherRepository voucherRepository,
            IVoucherAllocationRepository voucherAllocationRepository,
            IVoucherStatusRepository voucherStatusRepository,
            IVoucherTypeRepository voucherTypeRepository,

            IChargeTypeRepository chargeTypeRepository,
            IContractStatusRepository contractStatusRepository,

            IExpenseTypeRepository expenseTypeRepository,
            IPaymentMethodRepository paymentMethodRepository,
            IPaymentTimingTypeRepository paymentTimingTypeRepository,

            IUnitOfWork unitOfWork



            )
        {
           this.attachmentRepository = attachmentRepository;
           this.auditLogRepository = auditLogRepository;
           this.currencyRepository = currencyRepository;
           this.settingRepository = settingRepository;
           this.propertyExpenseAllocationRepoistory = propertyExpenseAllocationRepoistory;
           this.propertyExpenseRepoistory = propertyExpenseRepoistory;
           this.roleRopsitory = roleRopsitory;
           this.supplierRopsitory = supplierRopsitory;
           this.tenantRopsitory = tenantRopsitory;
           this.userRopsitory = userRopsitory;
           this.ownerRepository = ownerRepository;
           this.floorRepository = floorRepository;
           this. unitRepository = unitRepository;
           this.unitTypeRepository = unitTypeRepository;
           this.voucherRepository = voucherRepository;
           this.voucherAllocationRepository = voucherAllocationRepository;
           this. voucherStatusRepository = voucherStatusRepository;
           this. voucherTypeRepository = voucherTypeRepository;
           this. chargeTypeRepository = chargeTypeRepository;
           this.  contractStatusRepository = contractStatusRepository;
           this.  expenseTypeRepository = expenseTypeRepository;
           this.paymentMethodRepository = paymentMethodRepository;
           this.paymentTimingTypeRepository = paymentTimingTypeRepository;
           this. unitOfWork = unitOfWork;
        }
   


        public IAttachmentRepository AttachmentRepository => attachmentRepository;

        public IAuditLogRepository AuditLogRepository => auditLogRepository;

        public ICurrencyRepository CurrencyRepository => currencyRepository;

        public ISettingRepository SettingRepository => settingRepository;

        public IPropertyExpenseAllocationRepoistory PropertyExpenseAllocationRepoistory => propertyExpenseAllocationRepoistory;

        public IPropertyExpenseRepoistory PropertyExpenseRepoistory => propertyExpenseRepoistory;

        public IRoleRopsitory RoleRopsitory => roleRopsitory;

        public ISupplierRopsitory SupplierRopsitory => supplierRopsitory;

        public ITenantRopsitory TenantRopsitory => tenantRopsitory;

        public IUserRopsitory UserRopsitory => userRopsitory;

        public IOwnerRepository OwnerRepository => OwnerRepository;
        public IFloorRepository FloorRepository => floorRepository;

        public IPropertyRepository PropertyRepository => PropertyRepository;

        public IUnitRepository UnitRepository => unitRepository;
        public IUnitTypeRepository UnitTypeRepository => unitTypeRepository;

        public IVoucherRepository VoucherRepository => voucherRepository;

        public IVoucherAllocationRepository VoucherAllocationRepository => voucherAllocationRepository;
        public IVoucherStatusRepository VoucherStatusRepository => voucherStatusRepository;

        public IVoucherTypeRepository VoucherTypeRepository => voucherTypeRepository;


        public IChargeTypeRepository ChargeTypeRepository => chargeTypeRepository;

        public IContractStatusRepository ContractStatusRepository => contractStatusRepository;


        public IExpenseTypeRepository ExpenseTypeRepository => expenseTypeRepository;

        public IPaymentMethodRepository PaymentMethodRepository => PaymentMethodRepository;

        public IPaymentTimingTypeRepository PaymentTimingTypeRepository => PaymentTimingTypeRepository;
        public IUnitOfWork UnitOfWork => unitOfWork;
    }
}
