using Applebrie.Core.Entities;
using Applebrie.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Applebrie.Infrastructure.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        private readonly ApplebrieDbContext _dbContext;
        public UserRepository(ApplebrieDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByIdWithUserTypeAsync(int id, CancellationToken ct)
        {
            return await _dbContext.Users
                .Include(u => u.UserType)
                .SingleOrDefaultAsync(u => u.Id == id, ct);
        }
    }
}
