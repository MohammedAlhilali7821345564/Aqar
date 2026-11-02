using Aqar.Application.Interfaces.IRepository.Identity;
using Aqar.Domain.Identity;
using Aqar.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqar.Infrastructure.Repostres.Identity
{
    public class SupplierRopsitory : GenericRepository<Supplier>, ISupplierRopsitory
    {
        private ApplicationDbContext context;

        public SupplierRopsitory(ApplicationDbContext context) : base(context)
        {
           this.context = context;
        }
    }
}
