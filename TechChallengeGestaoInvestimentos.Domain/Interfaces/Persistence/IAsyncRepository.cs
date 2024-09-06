using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        // Novo método para verificar se existe algum registro que satisfaça a condição especificada
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}
