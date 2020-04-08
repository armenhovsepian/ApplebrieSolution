using Applebrie.Core.Entities;
using Applebrie.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Applebrie.Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T>, IDisposable where T : BaseEntity
    {
        private readonly ApplebrieDbContext _dbContext;

        public EfRepository(ApplebrieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken ct)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id, ct);
        }

        public async Task<IReadOnlyList<T>> GetAllListAsync(CancellationToken ct)
        {
            return await _dbContext.Set<T>().ToListAsync(ct);
        }

        public async Task<IReadOnlyList<T>> GetAllListAsync(ISpecification<T> spec, CancellationToken ct)
        {
            return await ApplySpecification(spec).ToListAsync(ct);
        }

        public async Task<T> AddAsync(T entity, CancellationToken ct)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync(ct);

            return entity;
        }

        public async Task UpdateAsync(T entity, CancellationToken ct)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(T entity, CancellationToken ct)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync(ct);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }
    }

}
