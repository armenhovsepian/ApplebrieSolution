using Microsoft.EntityFrameworkCore;

namespace Applebrie.Infrastructure
{
    public class ApplebrieDbContext : DbContext
    {
        public ApplebrieDbContext(DbContextOptions options):base(options)
        {
            
        }
    }
}
