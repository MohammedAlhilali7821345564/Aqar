using Aqar.Application.Interfaces.IRepository.Expenses;
using Aqar.Domain.Expenses;
using Aqar.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqar.Infrastructure.Repostres.Expenses
{
    public class PropertyExpenseAllocationRepoistory : GenericRepository<PropertyExpenseAllocation>, IPropertyExpenseAllocationRepoistory
    {
        private ApplicationDbContext context;

        public PropertyExpenseAllocationRepoistory(ApplicationDbContext context) : base(context)
        {
            this.context=context;
        }
    }
}
