using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities.Meta;

namespace checkout.com.api.Stores
{
    /// <summary>
    /// The generic interface for retrieval and storage of entities
    /// </summary>
    /// <typeparam name="T">
    /// The type of <see cref="IEntity"/> to store
    /// </typeparam>
    public interface IStore<T>
        where T : IEntity
    {
        /// <summary>
        /// Retrieve all entities
        /// </summary>
        /// <returns>
        /// The entities
        /// </returns>
        Task<IQueryable<T>> FindAllAsync();

        /// <summary>
        /// Retrieve an entity by id
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the entity
        /// </param>
        /// <returns>
        /// The entity
        /// </returns>
        Task<T> FindByIdAsync(string id);

        /// <summary>
        /// Add an entity
        /// </summary>
        /// <param name="entity">
        /// The entity to add
        /// </param>
        /// <returns>
        /// The added entity
        /// </returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Update an entity by id
        /// </summary>
        /// <param name="id">
        /// The id of the entity to be updated
        /// </param>
        /// <param name="entity">
        /// The update entity
        /// </param>
        /// <returns>
        /// The updated entity
        /// </returns>
        Task<T> UpdateAsync(string id, T entity);

        /// <summary>
        /// Delete an entity by id
        /// </summary>
        /// <param name="id">
        /// The id of the entity to be deleted
        /// </param>
        /// <returns>
        /// Success of delete operation
        /// </returns>
        Task<bool> DeleteAsync(string id);

        /// <summary>
        /// Get the number of entities
        /// </summary>
        /// <returns>
        /// The number of entities
        /// </returns>
        Task<int> Count();
    }
}