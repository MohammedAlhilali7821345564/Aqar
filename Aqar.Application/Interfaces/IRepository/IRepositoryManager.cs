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

namespace Aqar.Application.Interfaces.IRepository
{
    public interface IRepositoryManager
    {
        IAttachmentRepository AttachmentRepository { get; }
        IAuditLogRepository AuditLogRepository { get; }
        ICurrencyRepository CurrencyRepository { get; }
        ISettingRepository SettingRepository { get; }
        //Expense
        IPropertyExpenseAllocationRepoistory PropertyExpenseAllocationRepoistory { get; }
        IPropertyExpenseRepoistory    PropertyExpenseRepoistory { get; }
        //Identity
       IRoleRopsitory RoleRopsitory { get; }
        ISupplierRopsitory SupplierRopsitory { get; }
        ITenantRopsitory TenantRopsitory { get; }
        IUserRopsitory UserRopsitory { get; }

        // RealEstate
        IFloorRepository FloorRepository { get; }
        IOwnerRepository OwnerRepository { get; }
        IPropertyRepository PropertyRepository { get; }
        IUnitRepository UnitRepository { get; }
        //Vouchers
        IVoucherAllocationRepository VoucherAllocationRepository { get; }
        IVoucherRepository VoucherRepository { get; }
        //LookUps
        IChargeTypeRepository ChargeTypeRepository { get; }
        IContractStatusRepository ContractStatusRepository { get; }
        IExpenseTypeRepository ExpenseTypeRepository { get; }
        IPaymentMethodRepository PaymentMethodRepository { get; }
        IPaymentTimingTypeRepository PaymentTimingTypeRepository { get; }
        IUnitTypeRepository UnitTypeRepository { get; }
        IVoucherStatusRepository VoucherStatusRepository { get; }
        IVoucherTypeRepository VoucherTypeRepository { get; }

        IUnitOfWork UnitOfWork { get; }
    }
}
