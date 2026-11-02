using Aqar.Application.Interfaces.IRepository.Common;
using Aqar.Domain.Common;
using Aqar.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqar.Infrastructure.Repostres.Contracts
{
    public class AttachmentRepository : GenericRepository<Attachment>, IAttachmentRepository
    {
        private ApplicationDbContext context;

        public AttachmentRepository(ApplicationDbContext context) : base(context)
        {
          this.context = context;
        }
    }
}
