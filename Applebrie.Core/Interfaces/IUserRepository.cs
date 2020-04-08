using Applebrie.Core.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Applebrie.Core.Interfaces
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetByIdWithUserTypeAsync(int id, CancellationToken ct);
        Task<IEnumerable<User>> GetAllWithUserTypePagedListAsync(int take, int skip, CancellationToken ct);
    }
}
