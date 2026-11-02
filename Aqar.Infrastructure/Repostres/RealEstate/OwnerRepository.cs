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
    public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
    {
        private ApplicationDbContext context;

        public OwnerRepository(ApplicationDbContext context) : base(context)
        {
          this.context = context;
        }
    }
}
