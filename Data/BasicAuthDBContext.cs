using Microsoft.EntityFrameworkCore;

namespace MIDTERM_A1_BASICAUTH.Data
{
    public class BasicAuthDBContext : DbContext
    {
        public BasicAuthDBContext(DbContextOptions<BasicAuthDBContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
