using Microsoft.EntityFrameworkCore;
using StudentReg.Models;

namespace StudentReg.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
           : base(options)
        {
        }

        public DbSet<Registration> registrations { get; set; }
    }
}
