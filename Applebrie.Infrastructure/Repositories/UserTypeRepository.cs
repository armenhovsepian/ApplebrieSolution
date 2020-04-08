using Applebrie.Core.Entities;
using Applebrie.Core.Interfaces;

namespace Applebrie.Infrastructure.Repositories
{
    public class UserTypeRepository : EfRepository<UserType>, IUserTypeRepository
    {
        private readonly ApplebrieDbContext _dbContext;
        public UserTypeRepository(ApplebrieDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
