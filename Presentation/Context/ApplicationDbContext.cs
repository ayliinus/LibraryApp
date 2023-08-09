using Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }


    }
}

