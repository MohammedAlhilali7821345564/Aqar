using Aqar.Application.Interfaces.IRepository;
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
    public class PropertyExpenseRepoistory : GenericRepository<PropertyExpense>, IPropertyExpenseRepoistory
    {
        private ApplicationDbContext context;

        public PropertyExpenseRepoistory(ApplicationDbContext context) : base(context)
        {
            this.context=context;
        }
    }
}
