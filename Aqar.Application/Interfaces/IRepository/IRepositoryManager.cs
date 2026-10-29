using Aqar.Application.Interfaces.IRepository.Expenses;
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
        //Expense
        IPropertyExpenseAllocationRepoistory propertyExpenseAllocationRepoistory { get; }
        IPropertyExpenseRepoistory    propertyExpenseRepoistory { get; }
        // RealEstate
        IFloorRepository floorRepository { get; }
        IOwnerRepository OwnerRepository { get; }
        IPropertyRepository PropertyRepository { get; }
        IUnitRepository unitRepository { get; }
        //Vouchers
        IVoucherAllocationRepository voucherAllocationRepository { get; }
        IVoucherRepository voucherRepository { get; }
        //LookUps
        IChargeTypeRepository chargeTypeRepository { get; }
        IContractStatusRepository contractStatusRepository { get; }
        IExpenseTypeRepository expenseTypeRepository { get; }
        IPaymentMethodRepository waymentMethodRepository { get; }
        IPaymentTimingTypeRepository waymentTimingTypeRepository { get; }
        IUnitTypeRepository unitTypeRepository { get; }
        IVoucherStatusRepository voucherStatusRepository { get; }
        IVoucherTypeRepository voucherTypeRepository { get; }
    }
}
