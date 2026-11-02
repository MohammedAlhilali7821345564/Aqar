using Aqar.Application.Interfaces.IRepository.Vouchers;
using Aqar.Domain.Vouchers;
using Aqar.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqar.Infrastructure.Repostres.Vouchers
{
    public class VoucherRepository : GenericRepository<Voucher>, IVoucherRepository
    {
        private ApplicationDbContext context;

        public VoucherRepository(ApplicationDbContext context) : base(context)
        {
           this.context = context;
        }
    }
}
