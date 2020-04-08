using Applebrie.Core.Entities;
using Applebrie.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<User>> GetAllWithUserTypePagedListAsync(int take, int skip, CancellationToken ct)
        {
            return await _dbContext.Users
                .Include(u => u.UserType)
                .Skip(skip)
                .Take(take)
                .AsNoTracking()
                .ToListAsync(ct);
        }
    }
}
