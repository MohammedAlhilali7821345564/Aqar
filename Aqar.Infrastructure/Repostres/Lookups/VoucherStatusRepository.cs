using Aqar.Application.Interfaces.IRepository.Lookups;
using Aqar.Domain.Lookups;
using Aqar.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqar.Infrastructure.Repostres.Lookups
{
    public class VoucherStatusRepository : GenericRepository<VoucherStatus>, IVoucherStatusRepository
    {
        private ApplicationDbContext context;

        public VoucherStatusRepository(ApplicationDbContext context) : base(context)
        {
           this.context = context;
        }
    }
}
