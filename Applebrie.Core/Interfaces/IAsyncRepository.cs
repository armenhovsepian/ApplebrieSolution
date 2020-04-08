using Applebrie.Core.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Applebrie.Core.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id, CancellationToken ct);
        Task<IReadOnlyList<T>> GetAllListAsync(CancellationToken ct);
        Task<IReadOnlyList<T>> GetAllListAsync(ISpecification<T> spec, CancellationToken ct);
        Task<T> AddAsync(T entity, CancellationToken ct);
        Task UpdateAsync(T entity, CancellationToken ct);
        Task DeleteAsync(T entity, CancellationToken ct);
    }
}
