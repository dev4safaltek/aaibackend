using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AAI.RepositoryContract.Base
{
    public interface IBaseInterface<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get specific record by <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Record id.</param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(Guid id);

        /// <summary>
        /// Get all records.
        /// </summary>
        /// <returns></returns>
        Task<IList<TEntity>> GetAllAsync();

        /// <summary>
        /// Create record.
        /// </summary>
        /// <param name="model">Record that need to create.</param>
        /// <returns>Newly created record.</returns>
        Task<TEntity> CreateAsync(TEntity model);

        /// <summary>
        /// Update existing record.
        /// </summary>
        /// <param name="id">Id of the record that need to update.</param>
        /// <param name="model">Record that need to update.</param>
        /// <returns>Updated record.</returns>
        Task<TEntity> UpdateAsync(TEntity model);

        /// <summary>
        /// Update Range for existing record.
        /// </summary>
        /// <param name="id">Id of the record that need to update.</param>
        /// <param name="model">Record that need to update.</param>
        /// <returns>Updated record.</returns>
        Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> model);

        /// <summary>
        /// Delete specific record.
        /// </summary>
        /// <param name="id">Record id.</param>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Check if record exist or not.
        /// </summary>
        /// <param name="predicate">predicate of Record</param>
        /// <returns><c>true</c> if record exist, else <c>false</c>.</returns>
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IList<TEntity>> FindBy(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> FindBySync(Expression<Func<TEntity, bool>> predicate);
    }
}
