using Context;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MemberRepositoryService : BaseRepository<Member>, IMemberRepositoryService
    {
        public MemberRepositoryService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
