using Aqar.Application.Interfaces.IRepository.RealEstate;
using Aqar.Domain.RealEstate;
using Aqar.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqar.Infrastructure.Repostres.RealEstate
{
    public class UnitRepository : GenericRepository<Unit>, IUnitRepository
    {
        private ApplicationDbContext context;

        public UnitRepository(ApplicationDbContext context) : base(context)
        {
           this.context = context;
        }
    }
}
