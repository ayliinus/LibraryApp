using Context;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookRepositoryService : BaseRepository<Book>, IBookRepositoryService
    {
        public BookRepositoryService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
