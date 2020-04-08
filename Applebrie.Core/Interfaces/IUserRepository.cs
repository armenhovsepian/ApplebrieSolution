using Applebrie.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Applebrie.Core.Interfaces
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetByIdWithUserTypeAsync(int id);
        Task<IEnumerable<User>> ListAllWithUserTypeAsync();
    }
}
